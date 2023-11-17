namespace MRooster.Pokemon.Domain.DTOs;

public class AttackDto
{
    public int AttackId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Potence { get; set; }
    public int Precision { get; set; }
    public int PP { get; set; }
    public int Priority { get; set; }
    public AttackTypeDto Type { get; set; }
}
