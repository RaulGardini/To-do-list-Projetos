using ToDoList.DTOs.TarefasProjeto;

namespace ToDoList.Services.TarefasProjeto;

public interface IServiceTarefaProjeto
{
    Task<IEnumerable<ReadTarefaProjetoDTO>> GetAllByProjetoAsync(int projetoId);
    Task<ReadTarefaProjetoDTO?> GetByIdAsync(int tarefaId);
    Task<ReadTarefaProjetoDTO> CreateAsync(CreateTarefaProjetoDTO request);
    Task UpdateAsync(int tarefaId, UpdateTarefaProjetoDTO request);
    Task DeleteAsync(int tarefaId);
}