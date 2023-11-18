using MRooster.Pokemon.Domain.Models;

namespace MRooster.Pokemon.Domain.Abstractions;

public interface IPokemonRepository
{
    Task<IEnumerable<PokemonBase>> GetAll();
    Task<PokemonFull> GetFull(int pokemonId);
    Task<PokemonBase> GetBase(int pokemonId);
}
