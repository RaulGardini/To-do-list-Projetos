namespace ToDoList.DTOs.Tarefas;

public class UpdateTarefaDTO
{
    public string NomeTarefa { get; set; } = string.Empty;
    public char Status { get; set; }
}