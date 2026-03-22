using Microsoft.AspNetCore.Mvc;
using VisitesMediques.Application;
using VisitesMediques.Domain;

namespace VisitesMediques.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VisitesController : ControllerBase
{
    private readonly IVisitaMedicaRepository _repository;

    public VisitesController(IVisitaMedicaRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var visita = await _repository.GetByIdAsync(id);
        if (visita == null) return NotFound();
        return Ok(visita);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VisitaMedica visita)
    {
        var creada = await _repository.AddAsync(visita);
        return CreatedAtAction(nameof(Get), new { id = creada.IdVisita }, creada);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] VisitaMedica visita)
    {
        if (id != visita.IdVisita) return BadRequest();
        await _repository.UpdateAsync(visita);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
}