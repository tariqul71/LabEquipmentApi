using LabEquipmentApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace LabEquipmentApi.Data;

public class LabDbContext : DbContext
{
    public LabDbContext(DbContextOptions<LabDbContext> options)
        : base(options)
    {
    }

    public DbSet<Equipment> EquipmentItems => Set<Equipment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipment>().HasData(
            new Equipment
            {
                Id = 1,
                Name = "Projector",
                Room = "Lab 10",
                IsAvailable = true
            },
            new Equipment
            {
                Id = 2,
                Name = "Laptop",
                Room = "Lab 10",
                IsAvailable = false
            },
            new Equipment
            {
                Id = 3,
                Name = "Monitor",
                Room = "Lab 11",
                IsAvailable = true
            }
        );
    }
}
