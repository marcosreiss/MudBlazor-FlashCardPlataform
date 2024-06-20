using flascardStudy.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flashcardStudy.Api.Data.Mapping
{
    public class DeckMap : IEntityTypeConfiguration<DeckModel>
    {
        public void Configure(EntityTypeBuilder<DeckModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Decks");

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(x => x.Cards)
                .WithOne(x => x.Deck)
                .HasForeignKey(x => x.DeckId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
