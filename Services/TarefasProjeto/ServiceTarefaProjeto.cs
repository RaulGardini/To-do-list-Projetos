using ToDoList.DTOs.TarefasProjeto;
using ToDoList.Models;
using ToDoList.Repositories.Projetos;
using ToDoList.Repositories.TarefasProjeto;

namespace ToDoList.Services.TarefasProjeto;

public class ServiceTarefaProjeto : IServiceTarefaProjeto
{
    private readonly IRepositoryTarefaProjeto _repository;
    private readonly IRepositoryProjeto _projetoRepository;

    public ServiceTarefaProjeto(
        IRepositoryTarefaProjeto repository,
        IRepositoryProjeto projetoRepository)
    {
        _repository = repository;
        _projetoRepository = projetoRepository;
    }

    public async Task<IEnumerable<ReadTarefaProjetoDTO>> GetAllByProjetoAsync(int projetoId, Guid usuarioId)
    {
        // Só retorna tarefas se o projeto pertencer ao usuário logado.
        var projeto = await _projetoRepository.GetByIdAsync(projetoId, usuarioId);
        if (projeto is null) return Enumerable.Empty<ReadTarefaProjetoDTO>();

        var tarefas = await _repository.GetAllByProjetoAsync(projetoId);

        return tarefas.Select(t => new ReadTarefaProjetoDTO
        {
            TarefaId = t.TarefaId,
            ProjetoId = t.ProjetoId,
            Nome = t.Nome,
            Status = t.Status,
            Tipo = t.Tipo,
            Obs = t.Obs,
            DataInicio = t.DataInicio,
            DataFinal = t.DataFinal
        });
    }

    public async Task<ReadTarefaProjetoDTO?> GetByIdAsync(int tarefaId, Guid usuarioId)
    {
        var tarefa = await _repository.GetByIdAsync(tarefaId);
        if (tarefa is null) return null;

        // A tarefa existe, mas só é visível se o projeto dela for do usuário logado.
        var projeto = await _projetoRepository.GetByIdAsync(tarefa.ProjetoId, usuarioId);
        if (projeto is null) return null;

        return new ReadTarefaProjetoDTO
        {
            TarefaId = tarefa.TarefaId,
            ProjetoId = tarefa.ProjetoId,
            Nome = tarefa.Nome,
            Status = tarefa.Status,
            Tipo = tarefa.Tipo,
            Obs = tarefa.Obs,
            DataInicio = tarefa.DataInicio,
            DataFinal = tarefa.DataFinal
        };
    }

    public async Task<ReadTarefaProjetoDTO> CreateAsync(CreateTarefaProjetoDTO request, Guid usuarioId)
    {
        // Impede criar tarefa em projeto que não é do usuário.
        _ = await _projetoRepository.GetByIdAsync(request.ProjetoId, usuarioId)
            ?? throw new Exception("Projeto não encontrado.");

        var tarefa = new TarefaProjeto
        {
            ProjetoId = request.ProjetoId,
            Nome = request.Nome,
            Status = request.Status,
            Tipo = request.Tipo,
            Obs = request.Obs,
            DataInicio = request.DataInicio,
            DataFinal = request.DataFinal
        };

        await _repository.CreateAsync(tarefa);

        return new ReadTarefaProjetoDTO
        {
            TarefaId = tarefa.TarefaId,
            ProjetoId = tarefa.ProjetoId,
            Nome = tarefa.Nome,
            Status = tarefa.Status,
            Tipo = tarefa.Tipo,
            Obs = tarefa.Obs,
            DataInicio = tarefa.DataInicio,
            DataFinal = tarefa.DataFinal
        };
    }

    public async Task UpdateAsync(int tarefaId, UpdateTarefaProjetoDTO request, Guid usuarioId)
    {
        var tarefa = await GetTarefaDoUsuarioAsync(tarefaId, usuarioId);

        try
        {
            await _repository.UpdateAsync(tarefa, request);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task DeleteAsync(int tarefaId, Guid usuarioId)
    {
        var tarefa = await GetTarefaDoUsuarioAsync(tarefaId, usuarioId);
        await _repository.DeleteAsync(tarefa);
    }

    // Busca a tarefa garantindo que o projeto dela pertence ao usuário logado.
    private async Task<TarefaProjeto> GetTarefaDoUsuarioAsync(int tarefaId, Guid usuarioId)
    {
        var tarefa = await _repository.GetByIdAsync(tarefaId)
            ?? throw new Exception("Tarefa não encontrada.");

        _ = await _projetoRepository.GetByIdAsync(tarefa.ProjetoId, usuarioId)
            ?? throw new Exception("Tarefa não encontrada.");

        return tarefa;
    }
}
