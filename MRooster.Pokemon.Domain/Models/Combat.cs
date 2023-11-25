namespace MRooster.Pokemon.Domain.Models
{
    public class Combat
    {
        public PokemonBase PokemonOne { get; set; }
        public PokemonBase PokemonTwo { get; set; }
        public PokemonBase Winner { get; set; }
    }
}
