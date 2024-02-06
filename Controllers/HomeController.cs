using Microsoft.AspNetCore.Mvc;
using scoreGr03.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using scoreGr03.Data;

namespace scoreGr03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly scoreGr03Context _context; // Injection du contexte de base de données

        public HomeController(ILogger<HomeController> logger, scoreGr03Context context)
        {
            _logger = logger;
            _context = context; // Initialisation du contexte
        }
        


        public async Task<IActionResult> Index()
        {
            // Récupérez les matches depuis la base de données
            var matches = _context.Match
                .Include(m => m.EquipeDomicile) 
                .Include(m => m.EquipeExterieur) 
               
                .ToList(); // 
            

            // Passez les matches à la vue comme modèle
            return View(matches);
        }
    

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

