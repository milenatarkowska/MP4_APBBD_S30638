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
        
        base.OnModelCreating(modelBuilder);
    }
}