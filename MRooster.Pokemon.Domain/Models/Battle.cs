namespace MRooster.Pokemon.Domain.Models;

public class Battle
{
    public Team TeamOne { get; set; }
    public Team TeamTwo { get; set; }
    public List<Combat> Combats { get; set; }
}
