using Microsoft.AspNetCore.Mvc;
using MRooster.Pokemon.Domain.Abstractions;
using MRooster.Pokemon.Domain.Models;
using MrRooster.Pokemon.Models;
using System.Diagnostics;
using System.Reflection;

namespace MrRooster.Pokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly ITeamRepository _teamRepository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            IPokemonRepository pokemonRepository,
            ITeamRepository teamRepository)
        {
            _pokemonRepository = pokemonRepository;
            _teamRepository = teamRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _pokemonRepository.GetAll();
            var list2 = await _pokemonRepository.GetAll_New();

            var full = await _pokemonRepository.GetFull(2);

            var pokemon1 = await _pokemonRepository.GetBase(1);
            var pokemon2 = await _pokemonRepository.GetBase(2);
            var pokemon3 = await _pokemonRepository.GetBase(3);

            _teamRepository.Add(pokemon1);
            _teamRepository.Add(pokemon2);
            _teamRepository.Add(pokemon3);

            var myTeam = _teamRepository.GetMyTeam();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/team/{type?}")]
        public async Task<IActionResult> Team(string type)
        {
            var team = new Team();

            if (type == "myteam")
            {
                team = _teamRepository.GetMyTeam();
            }
            else
            {
                var allPokemon = await _pokemonRepository.GetAll();
                team = _teamRepository.GetRandomTeam(allPokemon.ToList());
            }

            var predominant = team.Pokemons
                   .SelectMany(pokemon => pokemon.Types)
                   .GroupBy(type => type)
                   .OrderByDescending(group => group.Count())
                   .Select(grupo => grupo.Key)
                   .First();

            var viewModel = new TeamViewModel
            {
                Team = team,
                Predominant = predominant,
                HeightAverage = team.Pokemons.Sum(x => x.Height) / team.Pokemons.Count,
                WeightAverage = team.Pokemons.Sum(x => x.Weight) / team.Pokemons.Count,
                Count = team.Pokemons.Count
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Battle()
        {
            return View(new BattleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> StartRandomBattle()
        {
            var allPokemon = await _pokemonRepository.GetAll();

            var teamOne = _teamRepository.GetRandomTeam(allPokemon.ToList());
            var teamTwo = _teamRepository.GetRandomTeam(allPokemon.ToList());

            var battle = BattleSimulator.Simulate(teamOne, teamTwo);

            var viewModel = new BattleViewModel
            {
                Battle = battle
            };

            return View("Battle", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> StartMyTeamBattle()
        {
            var allPokemon = await _pokemonRepository.GetAll();

            var teamOne = _teamRepository.GetMyTeam();
            var teamTwo = _teamRepository.GetRandomTeam(allPokemon.ToList(), teamOne.Pokemons.Count);

            var battle = BattleSimulator.Simulate(teamOne, teamTwo);

            var viewModel = new BattleViewModel
            {
                Battle = battle
            };

            return View("Battle", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
