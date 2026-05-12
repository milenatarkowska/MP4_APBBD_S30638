using System.ComponentModel.DataAnnotations;
namespace MP4_APBBD_S30638.DataModel;

public class ComponentManufacturer
{
    public int Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string Abbreviation { get; set; } = null!;
    
    [Required]
    [MaxLength(300)]
    public string FullName { get; set; } = null!;
    
    public DateTime FoundationDate { get; set; }
    
    public ICollection<Component> Components { get; set; }
        = new List<Component>();
}