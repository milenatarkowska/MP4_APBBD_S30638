using Microsoft.AspNetCore.Mvc;
using MP4_APBBD_S30638.DTOs;
using MP4_APBBD_S30638.Service.Interfaces;
namespace MP4_APBBD_S30638.Controllers;

[ApiController]
[Route("api/pcs")]
public class PcsController : ControllerBase
{
    private readonly IPcService _pcService;

    public PcsController(IPcService pcService)
    {
        _pcService = pcService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _pcService.GetAllAsync();

        return Ok(result);
    }
    

    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetComponents(int id)
    {
        var result = await _pcService.GetPcComponentsAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
    

    [HttpPost]
    public async Task<IActionResult> Create(PcPostDto dto)
    {
        var result = await _pcService.CreateAsync(dto);

        return Created($"api/pcs/{result.Id}", result);
    }
    

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, PcPutDto dto)
    {
        var updated = await _pcService.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return Ok();
    }
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _pcService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}