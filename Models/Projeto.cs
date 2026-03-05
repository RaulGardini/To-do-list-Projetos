namespace ToDoList.Models;

public class Projeto
{
    public int ProjetoId { get; set; }
    public string Nome { get; set; } = string.Empty;
    public char Status { get; set; } = 'P';
    public string? FrontStack { get; set; }
    public string? FrontObs { get; set; }
    public string? BackStack { get; set; }
    public string? BackObs { get; set; }
    public string? BancoDeDados { get; set; }
    public string? BancoDeDadosObs { get; set; }
    public DateOnly? DataInicio { get; set; }
    public DateOnly? DataFinal { get; set; }
    public Guid UsuarioId { get; set; }
    public string? Obs { get; set; }
}