using ToDoList.DTOs.TarefasProjeto;
using ToDoList.Models;
using ToDoList.Repositories.TarefasProjeto;

namespace ToDoList.Services.TarefasProjeto;

public class ServiceTarefaProjeto : IServiceTarefaProjeto
{
    private readonly IRepositoryTarefaProjeto _repository;

    public ServiceTarefaProjeto(IRepositoryTarefaProjeto repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ReadTarefaProjetoDTO>> GetAllByProjetoAsync(int projetoId)
    {
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

    public async Task<ReadTarefaProjetoDTO?> GetByIdAsync(int tarefaId)
    {
        var tarefa = await _repository.GetByIdAsync(tarefaId);
        if (tarefa is null) return null;

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

    public async Task<ReadTarefaProjetoDTO> CreateAsync(CreateTarefaProjetoDTO request)
    {
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

    public async Task UpdateAsync(int tarefaId, UpdateTarefaProjetoDTO request)
    {
        var tarefa = await _repository.GetByIdAsync(tarefaId)
            ?? throw new Exception("Tarefa não encontrada.");

        try
        {
            await _repository.UpdateAsync(tarefa, request);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }

    public async Task DeleteAsync(int tarefaId)
    {
        var tarefa = await _repository.GetByIdAsync(tarefaId)
            ?? throw new Exception("Tarefa não encontrada.");

        await _repository.DeleteAsync(tarefa);
    }
}