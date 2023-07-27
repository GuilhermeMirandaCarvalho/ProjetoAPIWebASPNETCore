using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAPIWebASPNETCoreC.Models;

[Table("Departamento")]
public class Departamento
{
    public Departamento()
    {
        Funcionarios = new Collection<Funcionario>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string? Nome { get; set; }

    public DateTime DataInclusao { get; set; }
    public ICollection<Funcionario>? Funcionarios { get; set; }
}