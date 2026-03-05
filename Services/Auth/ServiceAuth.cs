using ToDoList.DTOs.Auth;
using ToDoList.Models;
using ToDoList.Repositories.Auth;

namespace ToDoList.Services.Auth;

public class ServiceAuth : IServiceAuth
{
    private readonly IRepositoryAuth _repository;
    private readonly IServiceToken _tokenService;

    public ServiceAuth(IRepositoryAuth repository, IServiceToken tokenService)
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public async Task<ReadUsuarioDTO> RegisterAsync(CreateUsuarioDTO request)
    {
        if (await _repository.EmailExistsAsync(request.Email))
            throw new Exception("Email já cadastrado.");

        var usuario = new Usuario
        {
            Nome = request.Nome,
            Email = request.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha)
        };

        await _repository.CreateAsync(usuario);

        return new ReadUsuarioDTO
        {
            Token = _tokenService.GenerateToken(usuario),
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }

    public async Task<ReadUsuarioDTO> LoginAsync(LoginUsuarioDTO request)
    {
        var usuario = await _repository.GetByEmailAsync(request.Email)
            ?? throw new Exception("Email ou senha inválidos.");

        if (!BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
            throw new Exception("Email ou senha inválidos.");

        return new ReadUsuarioDTO
        {
            Token = _tokenService.GenerateToken(usuario),
            Nome = usuario.Nome,
            Email = usuario.Email
        };
    }
}