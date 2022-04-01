using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.SoftuniKaraoke
{
    class Award
    {
        public Award(string participant, List<string> awardList)
        {
            this.Participant = participant;
            this.AwardList = awardList;
        }

        public string Participant { get; set; }

        public List<string> AwardList { get; set; } = new List<string>();
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Award> printList = new List<Award>();
            List<string> participantsList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            List<string> songsList = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] command = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "dawn")
                {
                    break;
                }
                else
                {
                    string participant = command[0];
                    string song = command[1];
                    string award = command[2];

                    if (participantsList.Contains(participant) && songsList.Contains(song))
                    {
                        if (printList.Any(x => x.Participant == participant))
                        {
                            Award current = printList.First(x => x.Participant == participant);
                            if (!current.AwardList.Contains(award))
                            {
                                current.AwardList.Add(award);
                                continue;
                            }
                            continue;
                        }
                        
                        List<string> currentList = new List<string>() { award };
                        Award currentAward = new Award(participant, currentList);
                        printList.Add(currentAward);
                    }
                }
            }

            List<Award> primePrintList = printList.OrderByDescending(x => x.AwardList.Count).ThenBy(x => x.Participant).ToList();

            foreach (Award item in primePrintList)           //??????????????
            {
                item.AwardList = item.AwardList.OrderBy(x => x).ToList();
            }


            if (primePrintList.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            else
            {

                foreach (Award item in primePrintList)
                {
                    Console.WriteLine($"{item.Participant}: {item.AwardList.Count} awards");
                    for (int i = 0; i < item.AwardList.Count; i++)
                    {
                        Console.WriteLine($"--{item.AwardList[i]}");
                    }
                }
            }
        }
    }
}
