using Microsoft.EntityFrameworkCore;
using MillionRealStateCompany.Domain.Entities;

namespace MillionRealStateCompany.Infrastructure.Context
{
    public class MillionRealStateCompanyContext : DbContext
    {

        public MillionRealStateCompanyContext(DbContextOptions<MillionRealStateCompanyContext> options) : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().ToTable("Owners").Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Property>().ToTable("Properties").Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PropertyTrace>().ToTable("PropertyTraces").Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PropertyImage>().ToTable("PropertyImages").Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().ToTable("Users").Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Owner>()
                .HasMany(x => x.Properties)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId);

            modelBuilder.Entity<Property>()
               .HasOne(x => x.PropertyTrace)
               .WithOne(x => x.Property)
               .HasForeignKey<PropertyTrace>(x => x.PropertyId);

            modelBuilder.Entity<Property>()
              .HasMany(x => x.PropertyImages)
              .WithOne(x => x.Property)
              .HasForeignKey(x => x.PropertyId);

        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PropertyTrace> PropertyTraces { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
