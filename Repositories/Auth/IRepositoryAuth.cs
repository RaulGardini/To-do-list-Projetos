using ToDoList.Models;

namespace ToDoList.Repositories.Auth;

public interface IRepositoryAuth
{
    Task<Usuario?> GetByEmailAsync(string email);
    Task<Usuario> CreateAsync(Usuario usuario);
    Task<bool> EmailExistsAsync(string email);
}