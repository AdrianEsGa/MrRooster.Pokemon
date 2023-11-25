using MRooster.Pokemon.Domain.Models;

namespace MrRooster.Pokemon
{
    public static class BattleSimulator
    {
        public static Battle Simulate(Team teamOne, Team teamTwo)
        {
            var battle = new Battle
            {
                TeamOne = teamOne,
                TeamTwo = teamTwo,
                Combats = new List<Combat>()
            };

            for (int i = 0; i < battle.TeamOne.Pokemons.Count; i++)
            {
                var combat = new Combat
                {
                    PokemonOne = battle.TeamOne.Pokemons[i],
                    PokemonTwo = battle.TeamTwo.Pokemons[i]
                };

                battle.Combats.Add(combat);
            }

            foreach (var combat in battle.Combats)
            {
                combat.Winner = GetWinner(combat.PokemonOne, combat.PokemonTwo);
            }

            return battle;
        }

        private static PokemonBase GetWinner(PokemonBase pokemonOne, PokemonBase pokemonTwo)
        {
            var oneIsStrong = false;
            var twoIsStrong = false;

            foreach (var typesOne in pokemonOne.Types)
            {
                foreach (var typesTwo in pokemonTwo.Types)
                {
                    if (IsStrongThan(typesOne, typesTwo))
                    {
                        oneIsStrong = true;
                        break;
                    }
                }
            }

            foreach (var typesTwo in pokemonTwo.Types)
            {
                foreach (var typesOne in pokemonOne.Types)
                {
                    if (IsStrongThan(typesTwo, typesOne))
                    {
                        twoIsStrong = true;
                        break;
                    }
                }
            }

            if (oneIsStrong && !twoIsStrong)
            {
                return pokemonOne;
            }
            else if (!oneIsStrong && twoIsStrong)
            {
                return pokemonTwo;
            }
            else
            {
                if (pokemonOne.Height + pokemonOne.Weight > pokemonTwo.Height + pokemonTwo.Weight)
                {
                    return pokemonOne;
                }
                else
                {
                    return pokemonTwo;
                }
            }
        }

        private static bool IsStrongThan(PokemonType type1, PokemonType type2)
        {
            return type1.TypeName switch
            {
                "Fuego" => type2.TypeName == "Planta",
                "Agua" => type2.TypeName == "Fuego",
                "Planta" => type2.TypeName == "Agua",
                "Electrico" => type2.TypeName == "Agua" || type2.TypeName == "Volador",
                "Hielo" => type2.TypeName == "Planta" || type2.TypeName == "Tierra",
                "Volador" => type2.TypeName == "Planta" || type2.TypeName == "Lucha" || type2.TypeName == "Bicho",
                "Tierra" => type2.TypeName == "Fuego" || type2.TypeName == "Eléctrico",
                "Lucha" => type2.TypeName == "Normal" || type2.TypeName == "Hielo" || type2.TypeName == "Roca" || type2.TypeName == "Acero" || type2.TypeName == "Siniestro",
                "Veneno" => type2.TypeName == "Planta",
                "Roca" => type2.TypeName == "Fuego" || type2.TypeName == "Hielo" || type2.TypeName == "Volador" || type2.TypeName == "Bicho",
                "Bicho" => type2.TypeName == "Psíquico" || type2.TypeName == "Siniestro" || type2.TypeName == "Planta",
                "Fantasma" => type2.TypeName == "Psíquico" || type2.TypeName == "Fantasma",
                "Acero" => type2.TypeName == "Hielo" || type2.TypeName == "Roca" || type2.TypeName == "Hada",
                _ => false,
            };
        }
    }
}
