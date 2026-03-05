using ToDoList.DTOs.Projetos;
using ToDoList.Models;
using ToDoList.Repositories.Projetos;

namespace ToDoList.Services.Projetos;

public class ServiceProjeto : IServiceProjeto
{
    private readonly IRepositoryProjeto _repository;

    public ServiceProjeto(IRepositoryProjeto repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ReadProjetoDTO>> GetAllAsync(Guid usuarioId)
    {
        var projetos = await _repository.GetAllAsync(usuarioId);

        return projetos.Select(p => new ReadProjetoDTO
        {
            ProjetoId = p.ProjetoId,
            Nome = p.Nome,
            Status = p.Status,
            FrontStack = p.FrontStack,
            FrontObs = p.FrontObs,
            BackStack = p.BackStack,
            BackObs = p.BackObs,
            BancoDeDados = p.BancoDeDados,
            BancoDeDadosObs = p.BancoDeDadosObs,
            DataInicio = p.DataInicio,
            DataFinal = p.DataFinal,
            Obs = p.Obs
        });
    }

    public async Task<ReadProjetoDTO?> GetByIdAsync(int projetoId, Guid usuarioId)
    {
        var projeto = await _repository.GetByIdAsync(projetoId, usuarioId);
        if (projeto is null) return null;

        return new ReadProjetoDTO
        {
            ProjetoId = projeto.ProjetoId,
            Nome = projeto.Nome,
            Status = projeto.Status,
            FrontStack = projeto.FrontStack,
            FrontObs = projeto.FrontObs,
            BackStack = projeto.BackStack,
            BackObs = projeto.BackObs,
            BancoDeDados = projeto.BancoDeDados,
            BancoDeDadosObs = projeto.BancoDeDadosObs,
            DataInicio = projeto.DataInicio,
            DataFinal = projeto.DataFinal,
            Obs = projeto.Obs
        };
    }

    public async Task<ReadProjetoDTO> CreateAsync(CreateProjetoDTO request, Guid usuarioId)
    {
        var projeto = new Projeto
        {
            UsuarioId = usuarioId,
            Nome = request.Nome,
            Status = request.Status,
            FrontStack = request.FrontStack,
            FrontObs = request.FrontObs,
            BackStack = request.BackStack,
            BackObs = request.BackObs,
            BancoDeDados = request.BancoDeDados,
            BancoDeDadosObs = request.BancoDeDadosObs,
            DataInicio = request.DataInicio,
            DataFinal = request.DataFinal,
            Obs = request.Obs
        };

        await _repository.CreateAsync(projeto);

        return new ReadProjetoDTO
        {
            ProjetoId = projeto.ProjetoId,
            Nome = projeto.Nome,
            Status = projeto.Status,
            FrontStack = projeto.FrontStack,
            FrontObs = projeto.FrontObs,
            BackStack = projeto.BackStack,
            BackObs = projeto.BackObs,
            BancoDeDados = projeto.BancoDeDados,
            BancoDeDadosObs = projeto.BancoDeDadosObs,
            DataInicio = projeto.DataInicio,
            DataFinal = projeto.DataFinal,
            Obs = projeto.Obs
        };
    }

    public async Task UpdateAsync(int projetoId, UpdateProjetoDTO request, Guid usuarioId)
    {
        var projeto = await _repository.GetByIdAsync(projetoId, usuarioId)
            ?? throw new Exception("Projeto não encontrado.");

        try
        {
            await _repository.UpdateAsync(projeto, request);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task DeleteAsync(int projetoId, Guid usuarioId)
    {
        var projeto = await _repository.GetByIdAsync(projetoId, usuarioId)
            ?? throw new Exception("Projeto não encontrado.");

        await _repository.DeleteAsync(projeto);
    }
}