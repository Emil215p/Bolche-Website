using BolcheWebsite.Models;
using BolcheWebsite.SQLContext;
using BolcheWebsite.SQLModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace BolcheWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BirgerBolcherContext _context;

        public HomeController(ILogger<HomeController> logger, BirgerBolcherContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bolcher()
        {
            var combinationModel = new CombinationModel
            {
                BolcheView = _context.Set<BolcheView>().ToList(),
                NettoPris = _context.Set<NettoPri>().ToList(),
                TotalPris = _context.Set<TotalPri>().ToList(),
                HundredGramPris = _context.Set<HundredGramPri>().ToList()
            };

            return View(combinationModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
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