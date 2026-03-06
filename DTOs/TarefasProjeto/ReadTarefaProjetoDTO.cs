namespace ToDoList.DTOs.TarefasProjeto;

public class ReadTarefaProjetoDTO
{
    public int TarefaId { get; set; }
    public int ProjetoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public char Status { get; set; }
    public string? Tipo { get; set; }
    public string? Obs { get; set; }
    public DateOnly? DataInicio { get; set; }
    public DateOnly? DataFinal { get; set; }
}