namespace MP4_APBBD_S30638.DTOs;

public class PcPutDto
{
    // PUT api/pcs/{id}
    public string Name { get; set; } = null!;

    public float Weight { get; set; }

    public int Warranty { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Stock { get; set; }
}