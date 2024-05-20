using Microsoft.EntityFrameworkCore;
using Models;
using System.CodeDom;

namespace DataContext
{
    public class WalksDbContext : DbContext
    {
        public WalksDbContext(DbContextOptions<WalksDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasOne(r => r.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<UserRole>()
                .HasOne(u => u.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(u => u.UserId);
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
