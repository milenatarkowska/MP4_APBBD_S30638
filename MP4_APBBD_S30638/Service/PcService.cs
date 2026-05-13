using Microsoft.EntityFrameworkCore;
using MP4_APBBD_S30638.Data;
using MP4_APBBD_S30638.DataModel;
using MP4_APBBD_S30638.DTOs;
using MP4_APBBD_S30638.Service.Interfaces;

namespace MP4_APBBD_S30638.Service;

public class PcService : IPcService
{
    private readonly AppDataBaseContext _context;

    public PcService(AppDataBaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PcGetDto>> GetAllAsync()
    {
        return await _context.Pcs
            .Select(pc => new PcGetDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<PcComponentGetDto>?> GetPcComponentsAsync(int id)
    {
        var pcExists = await _context.Pcs.AnyAsync(p => p.Id == id);

        if (!pcExists)
            return null;

        return await _context.PcComponents
            .Where(pc => pc.PcId == id)
            .Select(pc => new PcComponentGetDto
            {
                ComponentCode = pc.ComponentCode,
                Name = pc.Component.Name,
                Type = pc.Component.ComponentType.Name,
                Amount = pc.Amount
            })
            .ToListAsync();
    }

    public async Task<PcPostResponseDto> CreateAsync(PcPostDto dto)
    {
        var pc = new Pc
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        _context.Pcs.Add(pc);

        await _context.SaveChangesAsync();

        return new PcPostResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdateAsync(int id, PcPutDto dto)
    {
        var pc = await _context.Pcs.FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null)
            return false;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var pc = await _context.Pcs.FirstOrDefaultAsync(p => p.Id == id);

        if (pc == null)
            return false;

        _context.Pcs.Remove(pc);

        await _context.SaveChangesAsync();

        return true;
    }
}