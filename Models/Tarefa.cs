namespace ToDoList.Models;

public class Tarefa
{
    public int TarefaId { get; set; }
    public Guid UsuarioId { get; set; }
    public string NomeTarefa { get; set; } = string.Empty;
    public char Status { get; set; } = 'P';
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
}