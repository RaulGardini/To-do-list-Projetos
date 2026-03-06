using ToDoList.Models;

namespace ToDoList.Repositories.TarefasProjeto;

public interface IRepositoryTarefaProjeto
{
    Task<IEnumerable<TarefaProjeto>> GetAllByProjetoAsync(int projetoId);
    Task<TarefaProjeto?> GetByIdAsync(int tarefaId);
    Task<TarefaProjeto> CreateAsync(TarefaProjeto tarefa);
    Task UpdateAsync(TarefaProjeto tarefa, object dto);
    Task DeleteAsync(TarefaProjeto tarefa);
}