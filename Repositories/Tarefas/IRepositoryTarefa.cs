using ToDoList.Models;

namespace ToDoList.Repositories.Tarefas;

public interface IRepositoryTarefa
{
    Task<IEnumerable<Tarefa>> GetAllByUsuarioAsync(Guid usuarioId);
    Task<Tarefa?> GetByIdAsync(int tarefaId, Guid usuarioId);
    Task<Tarefa> CreateAsync(Tarefa tarefa);
    Task UpdateAsync(Tarefa tarefa);
    Task DeleteAsync(Tarefa tarefa);
}