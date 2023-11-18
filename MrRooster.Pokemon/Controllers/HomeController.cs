using Microsoft.AspNetCore.Mvc;
using MRooster.Pokemon.Domain.Abstractions;
using MrRooster.Pokemon.Models;
using System.Diagnostics;

namespace MrRooster.Pokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;

        private readonly ILogger<HomeController> _logger;
  
        public HomeController(ILogger<HomeController> logger, IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _pokemonRepository.GetAll();

            var full = await _pokemonRepository.GetFull(3);

            return View();
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
