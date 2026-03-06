using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repositories.TarefasProjeto;

public class RepositoryTarefaProjeto : IRepositoryTarefaProjeto
{
    private readonly AppDbContext _context;

    public RepositoryTarefaProjeto(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TarefaProjeto>> GetAllByProjetoAsync(int projetoId)
        => await _context.TarefasProjeto
            .Where(t => t.ProjetoId == projetoId)
            .OrderBy(t => t.Tipo)
            .ThenBy(t => t.TarefaId)
            .ToListAsync();

    public async Task<TarefaProjeto?> GetByIdAsync(int tarefaId)
        => await _context.TarefasProjeto.FindAsync(tarefaId);

    public async Task<TarefaProjeto> CreateAsync(TarefaProjeto tarefa)
    {
        _context.TarefasProjeto.Add(tarefa);
        await _context.SaveChangesAsync();
        return tarefa;
    }

    public async Task UpdateAsync(TarefaProjeto tarefa, object dto)
    {
        foreach (var prop in dto.GetType().GetProperties())
        {
            var entityProp = typeof(TarefaProjeto).GetProperty(prop.Name);
            if (entityProp != null)
            {
                entityProp.SetValue(tarefa, prop.GetValue(dto));
                _context.Entry(tarefa).Property(prop.Name).IsModified = true;
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TarefaProjeto tarefa)
    {
        _context.TarefasProjeto.Remove(tarefa);
        await _context.SaveChangesAsync();
    }
}