using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs.Tarefas;
using ToDoList.Services.Tarefas;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TarefasController : ControllerBase
{
    private readonly IServiceTarefa _service;

    public TarefasController(IServiceTarefa service)
    {
        _service = service;
    }

    private Guid GetUsuarioId()
    {
        var claim = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        return Guid.Parse(claim);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tarefas = await _service.GetAllAsync(GetUsuarioId());
        return Ok(tarefas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var tarefa = await _service.GetByIdAsync(id, GetUsuarioId());
        return tarefa is null ? NotFound() : Ok(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTarefaDTO request)
    {
        var tarefa = await _service.CreateAsync(request, GetUsuarioId());
        return CreatedAtAction(nameof(GetById), new { id = tarefa.TarefaId }, tarefa);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTarefaDTO request)
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