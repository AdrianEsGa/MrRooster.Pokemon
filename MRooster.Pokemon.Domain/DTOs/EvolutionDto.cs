namespace MRooster.Pokemon.Domain.DTOs;

public class EvolutionDto
{
    public EvolutionTypeDto Type { get; set; }
    public int? Level { get; set; }
    public string Stone { get; set; }
}
