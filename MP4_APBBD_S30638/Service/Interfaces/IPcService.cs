using MP4_APBBD_S30638.DTOs;
namespace MP4_APBBD_S30638.Service.Interfaces;

public interface IPcService
{
    Task<IEnumerable<PcGetDto>> GetAllAsync();

    Task<IEnumerable<PcComponentGetDto>?> GetPcComponentsAsync(int id);

    Task<PcPostResponseDto> CreateAsync(PcPostDto dto);

    Task<bool> UpdateAsync(int id, PcPutDto dto);

    Task<bool> DeleteAsync(int id);
}