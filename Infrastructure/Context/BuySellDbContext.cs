using BuySellDotCom.Core.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class BuySellDbContext(DbContextOptions<BuySellDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Listing> Listings { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<Listing>()
            .HasOne(l => l.User)
            .WithMany(u => u.Listings)
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.Restrict);

             modelBuilder.Entity<Listing>().HasQueryFilter(l => !l.IsDeleted);

             modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted && u.IsActivated);




        }

    }
}
