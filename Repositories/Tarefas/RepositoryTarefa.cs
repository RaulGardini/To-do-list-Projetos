using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repositories.Tarefas;

public class RepositoryTarefa : IRepositoryTarefa
{
    private readonly AppDbContext _context;

    public RepositoryTarefa(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tarefa>> GetAllByUsuarioAsync(Guid usuarioId)
        => await _context.Tarefas
            .Where(t => t.UsuarioId == usuarioId)
            .OrderByDescending(t => t.CriadoEm)
            .ToListAsync();

    public async Task<Tarefa?> GetByIdAsync(int tarefaId, Guid usuarioId)
        => await _context.Tarefas
            .FirstOrDefaultAsync(t => t.TarefaId == tarefaId && t.UsuarioId == usuarioId);

    public async Task<Tarefa> CreateAsync(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }

    public async Task UpdateAsync(Tarefa tarefa)
    {
        _context.Entry(tarefa).Property(t => t.NomeTarefa).IsModified = true;
        _context.Entry(tarefa).Property(t => t.Status).IsModified = true;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Tarefa tarefa)
    {
        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();
    }
}