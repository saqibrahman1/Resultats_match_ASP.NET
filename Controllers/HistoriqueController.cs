using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using scoreGr03.Data;
using scoreGr03.Models;

namespace scoreGr03.Controllers;

public class HistoriqueController : Controller
{
    private readonly ILogger<HistoriqueController> _logger;
    private readonly scoreGr03Context _context; // Injection du contexte de base de données

    public HistoriqueController(ILogger<HistoriqueController> logger, scoreGr03Context context)
    {
        _logger = logger;
        _context = context; // Initialisation du contexte
    }

    // ... autres actions du contrôleur ...

    public async Task<IActionResult> Details(int id)
    {
        var match = await _context.Match
                .Include(m => m.Buts)
                .ThenInclude(b => b.Joueur)
                .ThenInclude(j => j.Equipe)
                .Include(m => m.EquipeDomicile) 
                .Include(m => m.EquipeExterieur)
                .FirstOrDefaultAsync(m => m.Id == id);

            

        if (match == null)
        {
            return NotFound();
        }

        return View(match);
    }

}