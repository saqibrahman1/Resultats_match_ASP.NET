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
    public class JoueursAPIController : ControllerBase
    {
        private readonly scoreGr03Context _context;

        public JoueursAPIController(scoreGr03Context context)
        {
            _context = context;
        }

        // GET: api/JoueursAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Joueur>>> GetJoueur()
        {
            return await _context.Joueur
                .ToListAsync();
        }

        // GET: api/JoueursAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Joueur>> GetJoueur(int id)
        {
            var joueur = await _context.Joueur.FindAsync(id);

            if (joueur == null)
            {
                return NotFound();
            }

            return joueur;
        }

        // PUT: api/JoueursAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoueur(int id, Joueur joueur)
        {
            if (id != joueur.Id)
            {
                return BadRequest();
            }

            _context.Entry(joueur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoueurExists(id))
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

        // POST: api/JoueursAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Joueur>> PostJoueur(Joueur joueur)
        {
            _context.Joueur.Add(joueur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJoueur", new { id = joueur.Id }, joueur);
        }

        // DELETE: api/JoueursAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoueur(int id)
        {
            var joueur = await _context.Joueur.FindAsync(id);
            if (joueur == null)
            {
                return NotFound();
            }

            _context.Joueur.Remove(joueur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JoueurExists(int id)
        {
            return _context.Joueur.Any(e => e.Id == id);
        }
    }
}
