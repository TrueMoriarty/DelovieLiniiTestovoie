using DAL.EFClasses;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class DelovieLiniiContext : DbContext
{
    public DelovieLiniiContext() {}
    public DelovieLiniiContext(DbContextOptions<DelovieLiniiContext> options) : base(options) 
    {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=master;User Id=sa;Password=Pass@word;TrustServerCertificate=True");
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Master> Masters { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<RepairRecord> RepairRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasMany(a => a.RepairRecords)
            .WithOne(b => b.Car)
            .HasForeignKey(c => c.CarId);

        modelBuilder.Entity<Master>()
            .HasMany(a => a.RepairRecords)
            .WithOne(b => b.Master)
            .HasForeignKey(c => c.MasterId);

        modelBuilder.Entity<Owner>()
            .HasMany(a => a.Cars)
            .WithOne(b => b.Owner)
            .HasForeignKey(c => c.OwnerId);

        base.OnModelCreating(modelBuilder);
    }

}