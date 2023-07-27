using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoAPIWebASPNETCoreC.Context;
using ProjetoAPIWebASPNETCoreC.Models;

namespace ProjetoAPIWebASPNETCoreC.Controllers
{           //api/Departamento/departamento2C
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            if (_context.Departamentos.IsNullOrEmpty())            
            {
                return NotFound("Nao encontrado");
            }            
            return await _context.Departamentos.ToListAsync();
        }

        // GET: api/Departamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            if (_context.Departamentos.IsNullOrEmpty())
            {
                return NotFound();
            }
            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return departamento;
        }


        // PUT: api/Departamento/2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return BadRequest();
            }

            _context.Entry(departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool DepartamentoExists(int id)
        {
            return (_context.Departamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }

}
