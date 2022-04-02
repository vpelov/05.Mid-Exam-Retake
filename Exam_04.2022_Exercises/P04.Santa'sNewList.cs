using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.Santa_sNewList
{
    class Gifts
    {
        public Gifts(string childName, string toyType, int amount)
        {
            this.ChildName = childName;
            this.ToyType = toyType;
            this.ToyAmount = amount;
        }

        public string ChildName { get; set; }

        public string ToyType { get; set; }

        public int ToyAmount { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Gifts> giftList = new List<Gifts>();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split("->", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                if (command[0] == "END")
                {
                    break;
                }
                else if (command[0] == "Remove")
                {
                    string childName = command[1];
                    for (int i = 0; i < giftList.Count; i++)
                    {
                        if (giftList[i].ChildName == childName)
                        {
                            Gifts current = giftList.Find(x => x.ChildName == childName);
                            current.ChildName = "badChild";
                        }
                    }
                }
                else
                {
                    string childName = command[0];
                    string typeOfToy = command[1];
                    int amount = int.Parse(command[2]);

                    Gifts curretGift = new Gifts(childName, typeOfToy, amount);
                    giftList.Add(curretGift);
                }
            }

            PrintGiftPerChild(giftList);
            PrintAllGift(giftList);

        }


        static void PrintGiftPerChild(List<Gifts> giftList)
        {
            Dictionary<string, int> printDict = new Dictionary<string, int>();
            foreach (Gifts item in giftList)
            {
                string name = item.ChildName;
                int amountGify = item.ToyAmount;
                if (!printDict.ContainsKey(name))
                {
                    Gifts current = giftList.First(x => x.ChildName == name);
                    printDict.Add(name, amountGify);
                }
                else
                {
                    printDict[name] += amountGify;                    
                }
            }

            Dictionary<string, int> newPrintDict = printDict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Children:");
            foreach (var item in newPrintDict)
            {
                if (item.Key != "badChild")
                {
                    Console.WriteLine($"{item.Key} -> {item.Value}");
                }
            }
        }



        static void PrintAllGift(List<Gifts> giftList)
        {
            Dictionary<string, int> typeGift = new Dictionary<string, int>();
            foreach (Gifts item in giftList)
            {
                if (typeGift.ContainsKey(item.ToyType))
                {
                    typeGift[item.ToyType] += item.ToyAmount;
                }
                else
                {
                    typeGift.Add(item.ToyType, item.ToyAmount);
                }
            }

            Console.WriteLine("Presents:");
            foreach (var item in typeGift)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }        
        }


    }
}
