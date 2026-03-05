using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs.Projetos;
using ToDoList.Services.Projetos;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjetosController : ControllerBase
{
    private readonly IServiceProjeto _service;

    public ProjetosController(IServiceProjeto service)
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
        var projetos = await _service.GetAllAsync(GetUsuarioId());
        return Ok(projetos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var projeto = await _service.GetByIdAsync(id, GetUsuarioId());
        return projeto is null ? NotFound() : Ok(projeto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjetoDTO request)
    {
        var projeto = await _service.CreateAsync(request, GetUsuarioId());
        return CreatedAtAction(nameof(GetById), new { id = projeto.ProjetoId }, projeto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateProjetoDTO request)
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