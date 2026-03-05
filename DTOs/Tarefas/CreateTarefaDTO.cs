namespace ToDoList.DTOs.Tarefas;

public class CreateTarefaDTO
{
    public string NomeTarefa { get; set; } = string.Empty;
    public char Status { get; set; } = 'P';
}