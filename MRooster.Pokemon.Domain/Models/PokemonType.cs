namespace MRooster.Pokemon.Domain.Models;

public class PokemonType
{
    public int TypeId { get; set; }
    public string TypeName { get; set; }

    public override string ToString()
    {
        return TypeName;
    }
}
