namespace MRooster.Pokemon.Domain.Models;

public class Evolution
{
    public EvolutionType Type { get; set; }
    public int? Level { get; set; }
    public string Stone { get; set; }
}
