using Microsoft.EntityFrameworkCore;
using TrendBankServer.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TrendBankServer.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Card> Cards { get; set; }
        public DbSet<Models.Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Transaction>()
                .HasOne<Models.Card>(e => e.CardTo)
                .WithMany(e => e.TransactionsTo)
                .HasForeignKey(t => t.CardToId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Models.Transaction>()
                .HasOne<Models.Card>(e => e.CardFrom)
                .WithMany(e => e.TransactionsFrom)
                .HasForeignKey(t => t.CardFromId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
