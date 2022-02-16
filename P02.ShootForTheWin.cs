using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.ShootForTheWin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            int countShot = 0;

            while (command != "End")
            {
                int indexShot = int.Parse(command);

                if (indexShot <= targets.Count - 1)
                {
                    countShot++;


                    int shot = targets[indexShot];
                    targets[indexShot] = -1;

                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] > shot && targets[i] != -1)
                        {
                            targets[i] -= shot;
                        }
                        else if (targets[i] <= shot && targets[i] != -1)
                        {
                            targets[i] += shot;
                        }
                    }

                }


                command = Console.ReadLine();
            }

            Console.Write($"Shot targets: {countShot} -> ");
            Console.WriteLine(String.Join(" ", targets));

        }
    }
}
