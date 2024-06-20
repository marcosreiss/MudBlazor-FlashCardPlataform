using flascardStudy.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace flashcardStudy.Api.Data.Mapping
{
    public class FlashCardMap : IEntityTypeConfiguration<FlashCardModel>
    {
        public void Configure(EntityTypeBuilder<FlashCardModel> builder)
        {
            builder.ToTable("FlashCards");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Front)
                .IsRequired(true)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Back)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);
        }
    }
}
