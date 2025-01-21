using FarmAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace FarmAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Farm> Farms { get; set; }
    public DbSet<Plant> Plants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //validação para a estação. (Season)
        modelBuilder.Entity<Plant>()
            .Property(p => p.Season)
            .HasConversion<string>()
            .IsRequired();

        modelBuilder.Entity<Farm>()
            .HasOne(f => f.CurrentPlant)
            .WithMany()
            .HasForeignKey(f => f.CurrentPlantId);
    }
}
