using BolcheWebsite.Models;
using BolcheWebsite.SQLContext;
using BolcheWebsite.SQLModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace BolcheWebsite.Controllers
{
    public class HomeController(BirgerBolcherContext context) : Controller
    {
        private readonly BirgerBolcherContext _context = context;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bolcher()
        {
            var combinationModel = new CombinationModel
            {
                BolcheView = [.. _context.Set<BolcheView>()],
                NettoPris = [.. _context.Set<NettoPri>()],
                TotalPris = [.. _context.Set<TotalPri>()],
                HundredGramPris = [.. _context.Set<HundredGramPri>()]
            };

            return View(combinationModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult KundeInfo()
        {
            var combinationModel = new CombinationModel
            {
                BolcheView = [.. _context.Set<BolcheView>()],
                NettoPris = [.. _context.Set<NettoPri>()],
                TotalPris = [.. _context.Set<TotalPri>()],
                HundredGramPris = [.. _context.Set<HundredGramPri>()]
            };

            return View(combinationModel);
        }

        public IActionResult Kontakt()
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