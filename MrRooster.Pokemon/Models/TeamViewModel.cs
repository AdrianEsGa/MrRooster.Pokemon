using MRooster.Pokemon.Domain.Models;

namespace MrRooster.Pokemon.Models
{
    public class TeamViewModel
    {
        public Team Team { get; set; }
        public PokemonType Predominant { get; set; }
        public double WeightAverage { get; set; }
        public double HeightAverage { get; set; }
        public int Count { get; set; }
    }
}
