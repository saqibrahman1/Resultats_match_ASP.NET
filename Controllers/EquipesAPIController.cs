using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoreGr03.Data;
using scoreGr03.Models;

namespace scoreGr03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipesAPIController : ControllerBase
    {
        private readonly scoreGr03Context _context;

        public EquipesAPIController(scoreGr03Context context)
        {
            _context = context;
        }

        // GET: api/EquipesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equipe>>> GetEquipe()
        {
            return await _context.Equipe
                
                .ToListAsync();
        }

        // GET: api/EquipesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equipe>> GetEquipe(int id)
        {
            var equipe = await _context.Equipe.FindAsync(id);

            if (equipe == null)
            {
                return NotFound();
            }

            return equipe;
        }

        // PUT: api/EquipesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquipe(int id, Equipe equipe)
        {
            if (id != equipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(equipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipeExists(id))
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

        // POST: api/EquipesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equipe>> PostEquipe(Equipe equipe)
        {
            _context.Equipe.Add(equipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquipe", new { id = equipe.Id }, equipe);
        }

        // DELETE: api/EquipesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipe(int id)
        {
            var equipe = await _context.Equipe.FindAsync(id);
            if (equipe == null)
            {
                return NotFound();
            }

            _context.Equipe.Remove(equipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquipeExists(int id)
        {
            return _context.Equipe.Any(e => e.Id == id);
        }
        
        
    }
}
