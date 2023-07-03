using System.Collections.ObjectModel;

namespace ProjetoAPIWebASPNETCoreC.Models;

public class Departamento
{
    public Departamento()
    {
        Funcionarios = new Collection<Funcionario>();
    }

    public int Id { get; set; }
    public string? Nome { get; set; }
    public DateTime DataInclusao { get; set; }
    public ICollection<Funcionario>? Funcionarios { get; set; }
}
