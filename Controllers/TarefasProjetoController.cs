using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs.TarefasProjeto;
using ToDoList.Services.TarefasProjeto;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TarefasProjetoController : ControllerBase
{
    private readonly IServiceTarefaProjeto _service;

    public TarefasProjetoController(IServiceTarefaProjeto service)
    {
        _service = service;
    }

    private Guid GetUsuarioId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return Guid.Parse(claim);
    }

    [HttpGet("projeto/{projetoId}")]
    public async Task<IActionResult> GetAllByProjeto(int projetoId)
    {
        var tarefas = await _service.GetAllByProjetoAsync(projetoId, GetUsuarioId());
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tarefa = await _service.GetByIdAsync(id, GetUsuarioId());
        return tarefa is null ? NotFound() : Ok(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTarefaProjetoDTO request)
    {
        try
        {
            var tarefa = await _service.CreateAsync(request, GetUsuarioId());
            return CreatedAtAction(nameof(GetById), new { id = tarefa.TarefaId }, tarefa);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTarefaProjetoDTO request)
    {
        try
        {
            await _service.UpdateAsync(id, request, GetUsuarioId());
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id, GetUsuarioId());
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
