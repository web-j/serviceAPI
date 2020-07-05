using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data
{
    public partial class SQLContext : DbContext
    {
        public SQLContext()
        {
        }
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => 
            {
                entity.Property(e => e.Created);
                entity.Property(e => e.LastUpdate);
                entity.Property(e => e.Erased);

                entity.HasIndex(e => e.Email)
                    .HasName("AK_User_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("AK_User_Username")
                    .IsUnique();

                entity.Property(e => e.Name);
                entity.Property(e => e.Sirname);
                entity.Property(e => e.Photo);
                entity.Property(e => e.Email);
                entity.Property(e => e.PhoneNumber);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.AccessRole);            
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
