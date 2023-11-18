namespace MRooster.Pokemon.Domain.Models
{
    public class PokemonFull : PokemonBase
    {
        public int PS { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Special { get; set; }
        public int Speed { get; set; }
        public IEnumerable<Attack> Attacks { get; set; }
        public IEnumerable<Evolution> Evolutions { get; set; }
        public IEnumerable<EvolutionFlow> EvolutionsFlow { get; set; }
        public IEnumerable<EvolutionFlow> InvolutionsFlow { get; set; }
    }
}
