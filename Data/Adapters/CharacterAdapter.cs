using PokemonShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonDataStore.Adapters
{
    public class CharacterAdapter
    {
        public static List<Character> GetCharacters()
        {
            List<Character> charactersList = new List<Character>();

            try
            {
                using (Entity.PocketMonstersEntities pmDB = new Entity.PocketMonstersEntities())
                {
                    foreach (Entity.CHARACTERS entityCharacter in pmDB.CHARACTERS)
                    {
                        long votes = 0;
                        Entity.RANKING entityRanking = entityCharacter.RANKING.FirstOrDefault<Entity.RANKING>();
                        if (entityRanking != null) votes = entityRanking.VOTES;

                        int count = pmDB.RANKING.Count<Entity.RANKING>(ranking => ranking.VOTES > votes);

                        List<string> characterClassName = new List<string>();
                        foreach (Entity.CLASSES entityClasses in entityCharacter.CLASSES)
                        {
                            characterClassName.Add(entityClasses.NAME);
                        }

                        List<Weakness> weaknessesList = new List<Weakness>();
                        foreach (Entity.WEAKNESS entityWeakness in entityCharacter.WEAKNESS)
                        {
                            weaknessesList.Add(new Weakness(entityWeakness.CLASSES.NAME, entityWeakness.RATIO));
                        }

                        Specifications specifications = new Specifications();
                        Entity.SPECIFICATIONS entitySpecifications = entityCharacter.SPECIFICATIONS.FirstOrDefault<Entity.SPECIFICATIONS>();
                        if (entitySpecifications != null) specifications = new Specifications(entitySpecifications.HEIGHT, entitySpecifications.WEIGHT, entitySpecifications.LIFEPOINTS, entitySpecifications.ATTACK, entitySpecifications.DEFENSE, entitySpecifications.SPECIALATTACK, entitySpecifications.SPECIALDEFENSE, entitySpecifications.SPEED);

                        Character character = new Character(entityCharacter.ID,
                            entityCharacter.NAME, count + 1, votes, characterClassName.ToArray(), entityCharacter.IMAGEFILE, specifications, weaknessesList.ToArray());

                        charactersList.Add(character);
                    }

                }
            } catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error while retrieving data.");
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return charactersList;
        }
    }
}
