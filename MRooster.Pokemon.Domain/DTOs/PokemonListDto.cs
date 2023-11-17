namespace MRooster.Pokemon.Domain.DTOs;

public class PokemonBaseDto
{
    public int PokemonId { get; set; }
    public string Name { get; set; }
    public List<PokemonTypeDto> Types { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
}

