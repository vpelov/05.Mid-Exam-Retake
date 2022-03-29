using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.HeroesOfCodeAndLogicVII
{
    class Hero
    {
        public Hero(string heroName, int hp, int mp)
        {
            this.HeroName = heroName;
            this.HP = hp;
            this.MP = mp;
        }

        public string HeroName { get; set; }

        public int HP { get; set; }

        public int MP { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroList = new List<Hero>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string heroName = inputData[0];
                int hp = int.Parse(inputData[1]);
                int mp = int.Parse(inputData[2]);
                Hero currentHero = new Hero(heroName, hp, mp);
                heroList.Add(currentHero);
            }

            while (true)
            {
                string commands = Console.ReadLine();
                if (commands == "End")
                {
                    break;
                }

                string[] commandArr = commands
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commandArr[0];

                if (command == "CastSpell")
                {
                    string heroName = commandArr[1];
                    int mpNeeded = int.Parse(commandArr[2]);
                    string spellName = commandArr[3];

                    Hero currentHero = heroList.Find(x => x.HeroName == heroName);
                    if (currentHero.MP >= mpNeeded)                                   // > | >= ?????
                    {
                        currentHero.MP -= mpNeeded;
                        Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {currentHero.MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (command == "TakeDamage")
                {
                    string heroName = commandArr[1];
                    int damage = int.Parse(commandArr[2]);
                    string attacker = commandArr[3];

                    Hero currentHero = heroList.Find(x => x.HeroName == heroName);
                    if (currentHero.HP > damage)
                    {
                        currentHero.HP -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {currentHero.HP} HP left!");
                    }
                    else
                    {
                        heroList.Remove(currentHero);
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                    }
                }
                else if (command == "Recharge")
                {
                    string heroName = commandArr[1];
                    int amount = int.Parse(commandArr[2]);

                    Hero currentHero = heroList.Find(x => x.HeroName == heroName);                    
                    if (currentHero.MP + amount <= 200)
                    {
                        currentHero.MP += amount;
                        Console.WriteLine($"{heroName} recharged for {amount} MP!");
                    }
                    else
                    {
                        int difference = 200 - currentHero.MP;
                        currentHero.MP = 200;
                        Console.WriteLine($"{heroName} recharged for {difference} MP!");
                    }

                }
                else if (command == "Heal")
                {
                    string heroName = commandArr[1];
                    int amount = int.Parse(commandArr[2]);

                    Hero currentHero = heroList.Find(x => x.HeroName == heroName);
                    if (currentHero.HP + amount <= 100)
                    {
                        currentHero.HP += amount;
                        Console.WriteLine($"{heroName} healed for {amount} HP!");
                    }
                    else
                    {
                        int difference = 100 - currentHero.HP;
                        currentHero.HP = 100;
                        Console.WriteLine($"{heroName} healed for {difference} HP!");
                    }
                }
            }

            foreach (Hero item in heroList)
            {
                Console.WriteLine(item.HeroName);
                Console.WriteLine($"  HP: {item.HP}");
                Console.WriteLine($"  MP: {item.MP}");
            }
        }
    }
}
