using MRooster.Pokemon.Domain.DTOs;

namespace MRooster.Pokemon.Domain.Abstractions;

public interface IPokemonRepository
{
    Task<IEnumerable<PokemonBaseDto>> GetAll();
    Task<IEnumerable<AttackDto>> GetAttacks(int pokemonId);
    Task<IEnumerable<EvolutionDto>> GetEvolutions(int pokemonId);
    Task<PokemonFullDto> GetFull(int pokemonId);
}
