using JT_InfoApi.Domain.Entities;
using JT_InfoApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JT_InfoApi.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }
        public DbSet<JT_Public_Holiday> JT_Public_Holidays { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublicHolidayResult>().HasNoKey();

            modelBuilder.Entity<Country>(builder =>
            {
                builder.ToTable("Countries");

                builder.HasKey(x => x.CountryCode);

                builder.Property(x => x.CountryCode)
                    .HasMaxLength(10)
                    .IsRequired();

                builder.Property(x => x.CountryDesc)
                    .HasMaxLength(100)
                    .IsRequired();

                builder.HasMany(x => x.Regions)
                    .WithOne(x => x.Country)
                    .HasForeignKey(x => x.CountryCode);
            });

            modelBuilder.Entity<Region>(builder =>
            {
                builder.ToTable("Regions");

                builder.HasKey(x => x.RegionCode);

                builder.Property(x => x.RegionCode)
                    .HasMaxLength(10)
                    .IsRequired();

                builder.Property(x => x.CountryCode)
                    .HasMaxLength(10)
                    .IsRequired();

                builder.HasOne(x => x.Country)
                    .WithMany(x => x.Regions)
                    .HasForeignKey(x => x.CountryCode);

                builder.HasMany(x => x.PublicHolidays)
                    .WithOne(x => x.Region)
                    .HasForeignKey(x => x.RegionCode);
            });

            modelBuilder.Entity<JT_Public_Holiday>(builder =>
            {
                builder.ToTable("JT_Public_Holidays");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.RegionCode)
                    .HasMaxLength(10)
                    .IsRequired();

                builder.Property(x => x.PHolDate)
                    .HasColumnType("date")
                    .IsRequired();

                builder.Property(x => x.PHolDesc)
                    .HasMaxLength(100)
                    .IsRequired();

                builder.Property(x => x.LastUpdated)
                    .HasColumnType("datetime")
                    .IsRequired();

                builder.HasOne(x => x.Region)
                    .WithMany(x => x.PublicHolidays)
                    .HasForeignKey(x => x.RegionCode);
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
