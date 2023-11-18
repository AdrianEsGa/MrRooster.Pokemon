namespace MRooster.Pokemon.Domain.Models;

public class EvolutionType
{
    public int TypeId { get; set; }
    public string TypeName { get; set; }

    public override string ToString()
    {
        return TypeName;
    }
}
