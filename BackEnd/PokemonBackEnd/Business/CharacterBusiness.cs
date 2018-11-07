using PokemonShared.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokemonBackEnd.Business
{
    public class CharacterBusiness
    {
        public static Specifications GetAverageSpecifications(string[] classesName, Character[] characters)
        {
            List<Character> listCharacters = GetListCharactersFromClassesName(classesName, characters);

            List<Specifications> specifications = new List<Specifications>();
            listCharacters.ForEach(chr => specifications.Add(chr.Specifications));

            long attack = 0;
            long defense = 0;
            long height = 0;
            long lifepoints = 0;
            long specialAttack = 0;
            long specialDefense = 0;
            long speed = 0;
            long weight = 0;

            if (specifications.Count > 0)
            {
                foreach (Specifications specification in specifications)
                {
                    attack += specification.Attack;
                    defense += specification.Defense;
                    height += specification.Height;
                    lifepoints += specification.LifePoints;
                    specialAttack += specification.SpecialAttack;
                    specialDefense += specification.SpecialDefense;
                    speed += specification.Speed;
                    weight += specification.Weight;
                }

                attack = attack / specifications.Count;
                defense = defense / specifications.Count;
                height = height / specifications.Count;
                lifepoints = lifepoints / specifications.Count;
                specialAttack = specialAttack / specifications.Count;
                specialDefense = specialDefense / specifications.Count;
                speed = speed / specifications.Count;
                weight = weight / specifications.Count;

            }
            return new Specifications(height, weight, lifepoints, attack, defense, specialAttack, specialDefense, speed);
        }

        private static List<Character> GetListCharactersFromClassesName(string[] classesName, Character[] characters)
        {
            List<Character> listCharacters = new List<Character>();
            foreach (string className in classesName)
            {
                listCharacters.AddRange(characters.ToList().Where<Character>(chr => chr.Classes.ToList<string>().Contains(className)).ToList<Character>());
            }
            return listCharacters;
        }
    }
}