using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAPIWebASPNETCoreC.Models;

[Table("Funcionario")]
public class Funcionario
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string? Nome { get; set; }

    [Required]
    [StringLength(200)]
    public string? Celular { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Salario { get; set; }

    public DateTime DataInclusao { get; set; }

    [ForeignKey("Departamento")]
    public int DepartamentoId { get; set; }

    public Departamento? Departamento { get; set; }
}