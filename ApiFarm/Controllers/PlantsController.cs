using FarmAPI.Data;
using FarmAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace FarmAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlantsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlantsController(AppDbContext context)
        =>
            _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAllPlants()
    {
        var plants = await _context.Plants.ToListAsync();
        return Ok(plants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPlantById(Guid id)
    {
        var plant = await _context.Plants.FindAsync(id);
        if (plant == null)
            return NotFound();

        return Ok(plant);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlant([FromBody] Plant plant)
    {
        _context.Plants.Add(plant);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPlantById), new { id = plant.Id }, plant);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlant(Guid id, [FromBody] Plant updatedPlant)
    {
        var plant = await _context.Plants.FindAsync(id);
        if (plant == null)
            return NotFound();

        plant.Name = updatedPlant.Name;
        plant.Description = updatedPlant.Description;
        plant.Season = updatedPlant.Season;
        plant.KeepOnCollect = updatedPlant.KeepOnCollect;
        plant.SpaceRequired = updatedPlant.SpaceRequired;
        plant.GrowthTime = updatedPlant.GrowthTime;
        plant.Value = updatedPlant.Value;
        plant.RequiredAchievements = updatedPlant.RequiredAchievements;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlant(Guid id)
    {
        var plant = await _context.Plants.FindAsync(id);
        if (plant == null)
            return NotFound();

        _context.Plants.Remove(plant);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
