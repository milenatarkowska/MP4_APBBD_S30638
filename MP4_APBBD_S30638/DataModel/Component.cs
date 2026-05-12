using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MP4_APBBD_S30638.DataModel;

public class Component
{
    [Key]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = null!;
    
    [Required]
    [MaxLength(300)]
    public string Name { get; set; } = null!;
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    public int ComponentManufacturerId { get; set; }
    
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    
    public int ComponentTypeId { get; set; }
    
    public ComponentType ComponentType { get; set; } = null!;
    
    public ICollection<PcComponent> PcComponents { get; set; }
        = new List<PcComponent>();
}