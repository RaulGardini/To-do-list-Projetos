using ToDoList.DTOs.Tarefas;

namespace ToDoList.Services.Tarefas;

public interface IServiceTarefa
{
    Task<IEnumerable<ReadTarefaDTO>> GetAllAsync(Guid usuarioId);
    Task<ReadTarefaDTO?> GetByIdAsync(int tarefaId, Guid usuarioId);
    Task<ReadTarefaDTO> CreateAsync(CreateTarefaDTO request, Guid usuarioId);
    Task UpdateAsync(int tarefaId, UpdateTarefaDTO request, Guid usuarioId);
    Task DeleteAsync(int tarefaId, Guid usuarioId);
}