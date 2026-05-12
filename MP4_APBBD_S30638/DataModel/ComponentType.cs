using System.ComponentModel.DataAnnotations;
namespace MP4_APBBD_S30638.DataModel;

public class ComponentType
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;
    
    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = null!;
    
    public ICollection<Component> Components { get; set; }
        = new List<Component>();
}