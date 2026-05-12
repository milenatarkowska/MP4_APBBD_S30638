using System.ComponentModel.DataAnnotations.Schema;
namespace MP4_APBBD_S30638.DataModel;

public class PcComponent
{
    public int PcId { get; set; }
    
    public Pc Pc { get; set; } = null!;
    
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = null!;
    
    public Component Component { get; set; } = null!;
    
    public int Amount { get; set; }
}