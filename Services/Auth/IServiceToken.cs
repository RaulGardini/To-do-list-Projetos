using ToDoList.Models;

namespace ToDoList.Services.Auth;

public interface IServiceToken
{
    string GenerateToken(Usuario usuario);
}