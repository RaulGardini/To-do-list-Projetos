using Microsoft.EntityFrameworkCore;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Repositories.Projetos;

public class RepositoryProjeto : IRepositoryProjeto
{
    private readonly AppDbContext _context;

    public RepositoryProjeto(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Projeto>> GetAllAsync(Guid usuarioId)
        => await _context.Projetos
            .Where(p => p.UsuarioId == usuarioId)
            .OrderByDescending(p => p.DataInicio)
            .ToListAsync();

    public async Task<Projeto?> GetByIdAsync(int projetoId, Guid usuarioId)
        => await _context.Projetos
            .FirstOrDefaultAsync(p => p.ProjetoId == projetoId && p.UsuarioId == usuarioId);

    public async Task<Projeto> CreateAsync(Projeto projeto)
    {
        _context.Projetos.Add(projeto);
        await _context.SaveChangesAsync();
        return projeto;
    }

    public async Task UpdateAsync(Projeto projeto, object dto)
    {
        foreach (var prop in dto.GetType().GetProperties())
        {
            var entityProp = typeof(Projeto).GetProperty(prop.Name);
            if (entityProp != null)
            {
                entityProp.SetValue(projeto, prop.GetValue(dto));
                _context.Entry(projeto).Property(prop.Name).IsModified = true;
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Projeto projeto)
    {
        _context.Projetos.Remove(projeto);
        await _context.SaveChangesAsync();
    }
}