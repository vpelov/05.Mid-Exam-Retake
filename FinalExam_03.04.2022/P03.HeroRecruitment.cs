using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.HeroRecruitment
{
    class Hero
    {
        public Hero(string name, List<string> spellList)
        {
            this.HeroName = name;
            this.SpellList = spellList;
        }

        public string HeroName { get; set; }

        public List<string> SpellList { get; set; } = new List<string>();
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroList = new List<Hero>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArr = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (cmdArr[0] == "Enroll")
                {
                    string heroName = cmdArr[1];
                    if (heroList.Any(x => x.HeroName == heroName))
                    {
                        Console.WriteLine($"{heroName} is already enrolled.");
                    }
                    else
                    {
                        List<string> currentList = new List<string>();
                        Hero current = new Hero(heroName, currentList);
                        heroList.Add(current);
                    }

                }
                else if (cmdArr[0] == "Learn")
                {
                    string heroName = cmdArr[1];
                    string spellName = cmdArr[2];
                    if (!heroList.Any(x => x.HeroName == heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                        
                    }
                    else
                    {
                        Hero current = heroList.First(x => x.HeroName == heroName);
                        if (current.SpellList.Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} has already learnt {spellName}.");
                        }
                        else
                        {
                            current.SpellList.Add(spellName);
                        }
                    }
                }
                else if (cmdArr[0] == "Unlearn")
                {
                    string heroName = cmdArr[1];
                    string spellName = cmdArr[2];
                    if (!heroList.Any(x => x.HeroName == heroName))
                    {
                        Console.WriteLine($"{heroName} doesn't exist.");
                    }
                    else
                    {
                        Hero currentHero = heroList.First(x => x.HeroName == heroName);
                        if (!currentHero.SpellList.Contains(spellName))
                        {
                            Console.WriteLine($"{heroName} doesn't know {spellName}.");
                        }
                        else
                        {
                            currentHero.SpellList.Remove(spellName);
                        }
                    }
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("Heroes:");
            foreach (Hero item in heroList)
            {
                Console.Write($"== {item.HeroName}: ");
                Console.WriteLine($"{string.Join(", ", item.SpellList)}");
            }


        }
    }
}
