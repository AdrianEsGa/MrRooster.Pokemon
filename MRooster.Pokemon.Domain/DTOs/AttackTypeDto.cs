namespace MRooster.Pokemon.Domain.DTOs;

public class AttackTypeDto
{
    public int TypeId { get; set; }
    public string TypeName { get; set; }

    public override string ToString()
    {
        return TypeName;
    }
}
