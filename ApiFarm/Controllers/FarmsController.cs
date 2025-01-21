using FarmAPI.Data;
using FarmAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FarmAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FarmsController : ControllerBase
{
    private readonly AppDbContext _context;

    public FarmsController(AppDbContext context)
        =>
            _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAllFarms()
        =>
        Ok(await _context.Farms.Include(f => f.CurrentPlant).ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFarmById(Guid id)
    {
        var farm = await _context.Farms.Include(f => f.CurrentPlant)
                                        .FirstOrDefaultAsync(f => f.Id == id);

        if (farm == null)
            return NotFound();
        return Ok(farm);
    }

    [HttpPost]
    public async Task<IActionResult> CreateFarm([FromBody] Farm farm)
    {
        _context.Farms.Add(farm);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetFarmById), new { id = farm.Id }, farm);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFarm(Guid id, [FromBody] Farm updatedFarm)
    {
        var farm = await _context.Farms.FindAsync(id);
        if (farm == null)
            return NotFound();

        farm.Owner = updatedFarm.Owner;
        farm.Capacity = updatedFarm.Capacity;
        farm.ReadyProducts = updatedFarm.ReadyProducts;
        farm.UsedSpace = updatedFarm.UsedSpace;
        farm.CurrentPlantId = updatedFarm.CurrentPlantId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFarm(Guid id)
    {
        var farm = await _context.Farms.FindAsync(id);
        if (farm == null)
            return NotFound();

        _context.Farms.Remove(farm);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
