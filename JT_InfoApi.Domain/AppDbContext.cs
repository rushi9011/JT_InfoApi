using JT_InfoApi.Domain.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
