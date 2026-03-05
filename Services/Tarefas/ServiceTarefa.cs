using ToDoList.DTOs.Tarefas;
using ToDoList.Models;
using ToDoList.Repositories.Tarefas;

namespace ToDoList.Services.Tarefas;

public class ServiceTarefa : IServiceTarefa
{
    private readonly IRepositoryTarefa _repository;

    public ServiceTarefa(IRepositoryTarefa repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ReadTarefaDTO>> GetAllAsync(Guid usuarioId)
    {
        var tarefas = await _repository.GetAllByUsuarioAsync(usuarioId);

        return tarefas.Select(t => new ReadTarefaDTO
        {
            TarefaId = t.TarefaId,
            NomeTarefa = t.NomeTarefa,
            Status = t.Status,
            CriadoEm = t.CriadoEm
        });
    }

    public async Task<ReadTarefaDTO?> GetByIdAsync(int tarefaId, Guid usuarioId)
    {
        var tarefa = await _repository.GetByIdAsync(tarefaId, usuarioId);
        if (tarefa is null) return null;

        return new ReadTarefaDTO
        {
            TarefaId = tarefa.TarefaId,
            NomeTarefa = tarefa.NomeTarefa,
            Status = tarefa.Status,
            CriadoEm = tarefa.CriadoEm
        };
    }

    public async Task<ReadTarefaDTO> CreateAsync(CreateTarefaDTO request, Guid usuarioId)
    {
        var tarefa = new Tarefa
        {
            UsuarioId = usuarioId,
            NomeTarefa = request.NomeTarefa,
            Status = request.Status
        };

        await _repository.CreateAsync(tarefa);

        return new ReadTarefaDTO
        {
            TarefaId = tarefa.TarefaId,
            NomeTarefa = tarefa.NomeTarefa,
            Status = tarefa.Status,
            CriadoEm = tarefa.CriadoEm
        };
    }

    public async Task UpdateAsync(int tarefaId, UpdateTarefaDTO request, Guid usuarioId)
    {
        var tarefa = await _repository.GetByIdAsync(tarefaId, usuarioId)
            ?? throw new Exception("Tarefa não encontrada.");

        tarefa.NomeTarefa = request.NomeTarefa;
        tarefa.Status = request.Status;

        await _repository.UpdateAsync(tarefa);
    }

    public async Task DeleteAsync(int tarefaId, Guid usuarioId)
    {
        var tarefa = await _repository.GetByIdAsync(tarefaId, usuarioId)
            ?? throw new Exception("Tarefa não encontrada.");

        await _repository.DeleteAsync(tarefa);
    }
}