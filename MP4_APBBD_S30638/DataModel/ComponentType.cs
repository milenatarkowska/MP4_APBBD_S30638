namespace MP4_APBBD_S30638.DataModel;

public class ComponentType
{
    public int Id { get; set; }
    public string Abbreviation { get; set; } = null!;
    public string Name { get; set; } = null!;
    public ICollection<Component> Components { get; set; }
        = new List<Component>();
}