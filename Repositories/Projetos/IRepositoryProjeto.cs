using ToDoList.Models;

namespace ToDoList.Repositories.Projetos;

public interface IRepositoryProjeto
{
    Task<IEnumerable<Projeto>> GetAllAsync(Guid usuarioId);
    Task<Projeto?> GetByIdAsync(int projetoId, Guid usuarioId);
    Task<Projeto> CreateAsync(Projeto projeto);
    Task UpdateAsync(Projeto projeto, object dto);
    Task DeleteAsync(Projeto projeto);
}