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
        public DbSet<Audit> Audits { get; set; }
        public DbSet<PublicHolidayResult> PublicHolidayResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublicHolidayResult>().HasNoKey().ToView(null);

            modelBuilder.Entity<Country>(builder =>
            {
                builder.ToTable("Countries");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.CtyCode)
                    .HasMaxLength(10)
                    .IsRequired();

                builder.HasIndex(x => x.CtyCode)
                    .IsUnique();

                builder.Property(x => x.CtyDesc)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<JT_Public_Holiday>(builder =>
            {
                builder.ToTable("JT_Public_Holidays");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.PHolDate)
                    .HasColumnType("date")
                    .IsRequired();

                builder.Property(x => x.PHolDesc)
                    .HasMaxLength(100)
                    .IsRequired();

                builder.Property(x => x.LastUpdated)
                    .HasColumnType("datetime")
                    .IsRequired();

                builder.HasOne(p => p.Country)
                .WithMany(c => c.PublicHolidays)
                .HasForeignKey(p => p.CtyId)
                .IsRequired(false);
            });

            modelBuilder.Entity<Audit>(entity =>
            {
                entity.ToTable("ApiAuditLogs");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.HttpMethod)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(e => e.Timestamp)
                    .HasDefaultValueSql("GETUTCDATE()");
            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
