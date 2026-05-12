namespace MP4_APBBD_S30638.DataModel;

public class Pc
{
    public int Id { get; set; }
    public String Name { get; set; }
    public float Weight { get; set; }
    public int Warranty { get; set; }
    public DateTime CreatedAt { get; set; }
    public int Stock { get; set; }
    public ICollection<PcComponent> PcComponents { get; set; }
        = new List<PcComponent>();
}