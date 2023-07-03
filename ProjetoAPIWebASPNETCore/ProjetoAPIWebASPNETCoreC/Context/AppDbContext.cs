using Microsoft.EntityFrameworkCore;
using ProjetoAPIWebASPNETCoreC.Models;

namespace ProjetoAPIWebASPNETCoreC.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        public DbSet<Departamento>? Departamentos { get; set; }
        public DbSet<Funcionario>? Funcionarios { get; set; }

    }
}
