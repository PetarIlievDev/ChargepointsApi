namespace Chargepoints.DataAccess
{
    using Chargepoints.DataAccess.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<ChargePoint> ChargePoints { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                .HasKey(l => l.LocationId);

            modelBuilder.Entity<Location>()
                .Property(l => l.Type)
                .HasConversion<string>();

            modelBuilder.Entity<ChargePoint>()
                .HasKey(c => c.ChargePointId);

            modelBuilder.Entity<ChargePoint>()
                .Property(l => l.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Location>()
                .HasMany(l => l.ChargePoints)
                .WithOne(c => c.Location)
                .HasForeignKey(c => c.LocationId);
        }
    }

}
