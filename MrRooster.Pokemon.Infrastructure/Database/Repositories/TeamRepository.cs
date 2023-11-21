using MRooster.Pokemon.Domain.Abstractions;
using MRooster.Pokemon.Domain.Models;

namespace MrRooster.Pokemon.Infrastructure.Database.Repositories;

public class TeamRepository : ITeamRepository
{
    private Team _myTeam { get; set; }
    private const int _maxTeamPokemons = 6;

    public TeamRepository()
    {
        _myTeam = new Team
        {
            Pokemons = new List<PokemonBase>()
        };
    }

    public bool Add(PokemonBase pokemon)
    {
        if (_myTeam.Pokemons.Count >= _maxTeamPokemons) return false;

        _myTeam.Pokemons.Add(pokemon);

        return true;
    }

    public Team GetMyTeam()
    {
        return _myTeam;
    }

    public Team GetRandomTeam(List<PokemonBase> allPokemons)
    {
        Team team = new()
        {
            Pokemons = new List<PokemonBase>()
        };

        Random random = new();

        for (int i = 0; i < _maxTeamPokemons; i++)
        {
            var index = random.Next(allPokemons.Count);
            team.Pokemons.Add(allPokemons[index]);
        }

        return team;
    }
}
