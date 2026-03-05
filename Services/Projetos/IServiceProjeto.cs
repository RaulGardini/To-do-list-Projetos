using ToDoList.DTOs.Projetos;

namespace ToDoList.Services.Projetos;

public interface IServiceProjeto
{
    Task<IEnumerable<ReadProjetoDTO>> GetAllAsync(Guid usuarioId);
    Task<ReadProjetoDTO?> GetByIdAsync(int projetoId, Guid usuarioId);
    Task<ReadProjetoDTO> CreateAsync(CreateProjetoDTO request, Guid usuarioId);
    Task UpdateAsync(int projetoId, UpdateProjetoDTO request, Guid usuarioId);
    Task DeleteAsync(int projetoId, Guid usuarioId);
}