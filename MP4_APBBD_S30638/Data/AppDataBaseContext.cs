using MP4_APBBD_S30638.DataModel;
using Microsoft.EntityFrameworkCore;

namespace MP4_APBBD_S30638.Data;

public class AppDataBaseContext : DbContext
{
    public AppDataBaseContext(DbContextOptions<AppDataBaseContext> options)
        : base(options)
    {
    }
    
    // tables
    public DbSet<Pc> Pcs { get; set; }

    public DbSet<Component> Components { get; set; }

    public DbSet<PcComponent> PcComponents { get; set; }

    public DbSet<ComponentType> ComponentTypes { get; set; }

    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PcComponent>()
            .HasKey(pc => new
            {
                pc.PcId,
                pc.ComponentCode
            });
        
        // 1 pc - * pc component
        modelBuilder.Entity<PcComponent>()
            .HasOne(pc => pc.Pc)
            .WithMany(p => p.PcComponents)
            .HasForeignKey(pc => pc.PcId);
        
        // 1 component - * pc component
        modelBuilder.Entity<PcComponent>()
            .HasOne(pc => pc.Component)
            .WithMany(c => c.PcComponents)
            .HasForeignKey(pc => pc.ComponentCode);
        
        // 1 component type - * component
        modelBuilder.Entity<Component>()
            .HasOne(c => c.ComponentType)
            .WithMany(ct => ct.Components)
            .HasForeignKey(c => c.ComponentTypeId);
        
        // 1 component manufacturer - * component
        modelBuilder.Entity<Component>()
            .HasOne(c => c.ComponentManufacturer)
            .WithMany(cm => cm.Components)
            .HasForeignKey(c => c.ComponentManufacturerId);
        
        // seed data
        //PC
        modelBuilder.Entity<Pc>().HasData(
            new Pc { Id = 1, Name = "Gaming PC", Weight = 8.5f, CreatedAt = new DateTime(2024, 1, 10), Stock = 5 },
            new Pc { Id = 2, Name = "Office PC", Weight = 6.2f, CreatedAt = new DateTime(2024, 2, 15), Stock = 10 },
            new Pc { Id = 3, Name = "Workstation", Weight = 12.0f, CreatedAt = new DateTime(2024, 3, 20), Stock = 3 }
        );
        //PCComponent
        modelBuilder.Entity<PcComponent>().HasData(
            new PcComponent { PcId = 1, ComponentCode = "C1", Amount = 1 },
            new PcComponent { PcId = 1, ComponentCode = "C3", Amount = 1 },
            new PcComponent { PcId = 2, ComponentCode = "C1", Amount = 1 }
        );
        //Component
        modelBuilder.Entity<Component>().HasData(
            new Component { Code = "C1", Name = "Intel i7", Description = "CPU", ComponentTypeId = 1, ComponentManufacturerId = 1 },
            new Component { Code = "C2", Name = "Ryzen 9", Description = "CPU", ComponentTypeId = 1, ComponentManufacturerId = 2 },
            new Component { Code = "C3", Name = "RTX 4080", Description = "GPU", ComponentTypeId = 2, ComponentManufacturerId = 3 }
        );
        //Component type
        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "RAM", Name = "Memory" }
        );
        //Component manufacturer
        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer { Id = 1, Abbreviation = "INT", FullName = "Intel", FoundationDate = new DateTime(1968, 7, 18) },
            new ComponentManufacturer { Id = 2, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateTime(1969, 5, 1) },
            new ComponentManufacturer { Id = 3, Abbreviation = "NVD", FullName = "NVIDIA", FoundationDate = new DateTime(1993, 4, 5) }
        );
        base.OnModelCreating(modelBuilder);
    }
}