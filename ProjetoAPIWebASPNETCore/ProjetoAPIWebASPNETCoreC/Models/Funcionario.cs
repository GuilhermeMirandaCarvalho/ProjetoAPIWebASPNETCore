namespace ProjetoAPIWebASPNETCoreC.Models;

public class Funcionario
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Celular { get; set; }
    public string? Salario { get; set; }
    public DateTime DataInclusao { get; set; }
    public int DepartamentoId { get; set; }
    public Departamento? Departamento { get; set; }
}
