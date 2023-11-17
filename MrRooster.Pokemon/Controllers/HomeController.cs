﻿using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index(int? peso, int? alturea, string? tipo)
        {
            var list = await _pokemonRepository.GetAll();

            var attacks = await _pokemonRepository.GetAttacks(list.First().PokemonId);

            var evolutions = await _pokemonRepository.GetEvolutions(list.First().PokemonId);

            var full = await _pokemonRepository.GetFull(list.First().PokemonId);

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