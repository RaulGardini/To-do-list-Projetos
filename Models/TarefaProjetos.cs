namespace ToDoList.Models;

public class TarefaProjeto
{
    public int TarefaId { get; set; }
    public int ProjetoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public char Status { get; set; } = 'P';
    public string? Tipo { get; set; }
    public string? Obs { get; set; }
    public DateOnly? DataInicio { get; set; }
    public DateOnly? DataFinal { get; set; }
}