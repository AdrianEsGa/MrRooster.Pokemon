namespace MRooster.Pokemon.Domain.Models;

public class PokemonBase
{
    public int PokemonId { get; set; }
    public string Name { get; set; }
    public List<PokemonType> Types { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
}

