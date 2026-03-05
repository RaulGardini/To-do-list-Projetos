namespace ToDoList.DTOs.Tarefas;

public class ReadTarefaDTO
{
    public int TarefaId { get; set; }
    public string NomeTarefa { get; set; } = string.Empty;
    public char Status { get; set; }
    public DateTime CriadoEm { get; set; }
}