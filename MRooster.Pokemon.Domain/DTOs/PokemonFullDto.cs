namespace MRooster.Pokemon.Domain.DTOs
{
    public class PokemonFullDto : PokemonBaseDto
    {
        public int PS { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Special { get; set; }
        public int Speed { get; set; }
        public IEnumerable<AttackDto> Attacks { get; set; }
        public IEnumerable<EvolutionDto> Evolutions { get; set; }  
    }
}
