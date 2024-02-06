﻿using System;
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
    public class MatchesController : Controller
    {
        private readonly scoreGr03Context _context;

        public MatchesController(scoreGr03Context context)
        {
            _context = context;
        }
        

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var scoreGr03Context = _context.Match.Include(m => m.EquipeDomicile).Include(m => m.EquipeExterieur);
            return View(await scoreGr03Context.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.EquipeDomicile)
                .Include(m => m.EquipeExterieur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["EquipeDomicileId"] = new SelectList(_context.Set<Equipe>(), "Id", "Nom");
            ViewData["EquipeExterieurId"] = new SelectList(_context.Set<Equipe>(), "Id", "Nom");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateHeure,ScoreDomicile,ScoreExterieur,EquipeDomicileId,EquipeExterieurId")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipeDomicileId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeDomicileId);
            ViewData["EquipeExterieurId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeExterieurId);
            return View(match);
        }
*/
        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["EquipeDomicileId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeDomicileId);
            ViewData["EquipeExterieurId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeExterieurId);
            return View(match);
        }

     /*   // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateHeure,ScoreDomicile,ScoreExterieur,EquipeDomicileId,EquipeExterieurId")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
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
            ViewData["EquipeDomicileId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeDomicileId);
            ViewData["EquipeExterieurId"] = new SelectList(_context.Set<Equipe>(), "Id", "Id", match.EquipeExterieurId);
            return View(match);
        }
        */ 
        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.EquipeDomicile)
                .Include(m => m.EquipeExterieur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

      /*  // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Match.FindAsync(id);
            if (match != null)
            {
                _context.Match.Remove(match);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
*/
        private bool MatchExists(int id)
        {
            return _context.Match.Any(e => e.Id == id);
        }
    }
}
