namespace MP4_APBBD_S30638.DTOs;

public class PcComponentGetDto
{
    // GET api/pcs/{id}/components
    public string ComponentCode { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int Amount { get; set; }
}