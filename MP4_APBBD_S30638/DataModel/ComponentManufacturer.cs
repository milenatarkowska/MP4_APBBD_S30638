namespace MP4_APBBD_S30638.DataModel;

public class ComponentManufacturer
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int FoundedYear { get; set; }
    public ICollection<Component> Components { get; set; }
        = new List<Component>();
}