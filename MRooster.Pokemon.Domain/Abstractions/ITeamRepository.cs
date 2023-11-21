using MRooster.Pokemon.Domain.Models;

namespace MRooster.Pokemon.Domain.Abstractions;

public interface ITeamRepository
{
    bool Add(PokemonBase pokemon);
    Team GetMyTeam();
    Team GetRandomTeam(List<PokemonBase> allPokemons);
}
