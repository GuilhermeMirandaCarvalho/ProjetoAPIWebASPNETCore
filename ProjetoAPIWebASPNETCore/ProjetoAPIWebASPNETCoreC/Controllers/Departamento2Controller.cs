using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoAPIWebASPNETCoreC.Context;
using ProjetoAPIWebASPNETCoreC.Models;

namespace ProjetoAPIWebASPNETCoreC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Departamento2Controller : ControllerBase
    {
        private readonly AppDbContext _context;

        public Departamento2Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Departamento2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
        {
            if (_context.Departamentos == null)
            {
                return NotFound();
            }
            return await _context.Departamentos.ToListAsync();
        }

        // GET: api/Departamento2/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            if (_context.Departamentos == null)
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

        // PUT: api/Departamento2/1
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

        // POST: api/Departamento2
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            if (_context.Departamentos == null)
            {
                return Problem("Entity set 'AppDbContext.Departamentos'  is null.");
            }
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartamento", new { id = departamento.Id }, departamento);
        }

        // DELETE: api/Departamento2/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            if (_context.Departamentos == null)
            {
                return NotFound();
            }
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentoExists(int id)
        {
            return (_context.Departamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
