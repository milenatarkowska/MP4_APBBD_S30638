namespace MP4_APBBD_S30638.DTOs;

public class PcPostDto
{
    // POST api/pcs
    public string Name { get; set; } = null!;

    public float Weight { get; set; }

    public int Warranty { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Stock { get; set; }
}