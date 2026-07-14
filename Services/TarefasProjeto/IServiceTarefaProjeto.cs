using ToDoList.DTOs.TarefasProjeto;

namespace ToDoList.Services.TarefasProjeto;

public interface IServiceTarefaProjeto
{
    Task<IEnumerable<ReadTarefaProjetoDTO>> GetAllByProjetoAsync(int projetoId, Guid usuarioId);
    Task<ReadTarefaProjetoDTO?> GetByIdAsync(int tarefaId, Guid usuarioId);
    Task<ReadTarefaProjetoDTO> CreateAsync(CreateTarefaProjetoDTO request, Guid usuarioId);
    Task UpdateAsync(int tarefaId, UpdateTarefaProjetoDTO request, Guid usuarioId);
    Task DeleteAsync(int tarefaId, Guid usuarioId);
}
