using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using scoreGr03.Data;
using scoreGr03.Models;

namespace scoreGr03.Controllers
{
    public class ButsController : Controller
    {
        private readonly scoreGr03Context _context;

        public ButsController(scoreGr03Context context)
        {
            _context = context;
        }

        // GET: Buts
        public async Task<IActionResult> Index()
        {
            var scoreGr03Context = _context.But.Include(b => b.Joueur).Include(b => b.Match);
            return View(await scoreGr03Context.ToListAsync());
        }

        // GET: Buts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var but = await _context.But
                .Include(b => b.Joueur)
                .Include(b => b.Match)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (but == null)
            {
                return NotFound();
            }

            return View(but);
        }

        // GET: Buts/Create
        public IActionResult Create()
        {
            ViewData["JoueurId"] = new SelectList(_context.Set<Joueur>(), "Id", "Prenom");
            ViewData["MatchId"] = new SelectList(_context.Match, "Id", "Id");
            return View();
        }

      /*  // POST: Buts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temps,JoueurId,MatchId")] But but)
        {
            if (ModelState.IsValid)
            {
                _context.Add(but);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JoueurId"] = new SelectList(_context.Set<Joueur>(), "Id", "Id", but.JoueurId);
            ViewData["MatchId"] = new SelectList(_context.Match, "Id", "Id", but.MatchId);
            return View(but);
        }
*/
        // GET: Buts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var but = await _context.But.FindAsync(id);
            if (but == null)
            {
                return NotFound();
            }
            ViewData["JoueurId"] = new SelectList(_context.Set<Joueur>(), "Id", "Id", but.JoueurId);
            ViewData["MatchId"] = new SelectList(_context.Match, "Id", "Id", but.MatchId);
            return View(but);
        }
/*
        // POST: Buts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temps,JoueurId,MatchId")] But but)
        {
            if (id != but.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(but);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ButExists(but.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["JoueurId"] = new SelectList(_context.Set<Joueur>(), "Id", "Id", but.JoueurId);
            ViewData["MatchId"] = new SelectList(_context.Match, "Id", "Id", but.MatchId);
            return View(but);
        }
*/
        // GET: Buts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var but = await _context.But
                .Include(b => b.Joueur)
                .Include(b => b.Match)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (but == null)
            {
                return NotFound();
            }

            return View(but);
        }
/*
        // POST: Buts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var but = await _context.But.FindAsync(id);
            if (but != null)
            {
                _context.But.Remove(but);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
*/
        private bool ButExists(int id)
        {
            return _context.But.Any(e => e.Id == id);
        }
    }
}
