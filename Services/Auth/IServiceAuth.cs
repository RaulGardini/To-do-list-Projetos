using ToDoList.DTOs.Auth;

namespace ToDoList.Services.Auth;

public interface IServiceAuth
{
    Task<ReadUsuarioDTO> RegisterAsync(CreateUsuarioDTO request);
    Task<ReadUsuarioDTO> LoginAsync(LoginUsuarioDTO request);
}