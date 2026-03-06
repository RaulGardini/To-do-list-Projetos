namespace ToDoList.DTOs.TarefasProjeto;

public class UpdateTarefaProjetoDTO
{
    public string Nome { get; set; } = string.Empty;
    public char Status { get; set; }
    public string? Tipo { get; set; }
    public string? Obs { get; set; }
    public DateOnly? DataInicio { get; set; }
    public DateOnly? DataFinal { get; set; }
}