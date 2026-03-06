namespace ToDoList.DTOs.TarefasProjeto;

public class CreateTarefaProjetoDTO
{
    public int ProjetoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public char Status { get; set; } = 'P';
    public string? Tipo { get; set; }
    public string? Obs { get; set; }
    public DateOnly? DataInicio { get; set; }
    public DateOnly? DataFinal { get; set; }
}