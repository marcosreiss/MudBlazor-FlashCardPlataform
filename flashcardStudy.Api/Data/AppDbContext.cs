using flascardStudy.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace flashcardStudy.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<FlashCardModel> FlashCards { get; set; } = null!;
        public DbSet<DeckModel> Decks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
    }
}
