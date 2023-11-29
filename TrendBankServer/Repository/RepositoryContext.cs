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
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Models.Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Card>()
                .HasMany<Models.Transaction>(e => e.TransactionsTo)
                .WithOne(e => e.CardTo)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Card>()
                .HasMany<Models.Transaction>(e => e.TransactionsFrom)
                .WithOne(e => e.CardFrom)
                .OnDelete(DeleteBehavior.ClientNoAction);*/

            modelBuilder.Entity<Models.Transaction>()
                .HasOne<Card>(e => e.CardTo)
                .WithMany(e => e.TransactionsTo)
                .HasForeignKey(t => t.CardToId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Models.Transaction>()
                .HasOne<Card>(e => e.CardFrom)
                .WithMany(e => e.TransactionsFrom)
                .HasForeignKey(t => t.CardFromId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
