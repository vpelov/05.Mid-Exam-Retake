using System;

namespace P01.BiscuitFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double biscuitsPerDeysWorker = int.Parse(Console.ReadLine());
            double numberWorker = int.Parse(Console.ReadLine());
            double needBiscuitsForMonth = int.Parse(Console.ReadLine());

            double sumPerDay = biscuitsPerDeysWorker * numberWorker;

            double thirdDay = Math.Floor((biscuitsPerDeysWorker * numberWorker) * 0.75);

            double total = Math.Floor((sumPerDay * 20) + (thirdDay * 10));

            double onePrecentage = needBiscuitsForMonth / 100;


            Console.WriteLine($"You have produced {total} biscuits for the past month.");

            if (total >= needBiscuitsForMonth)
            {
                Console.WriteLine($"You produce { (total / onePrecentage) - 100:f2} percent more biscuits.");

            }
            else
            {
                Console.WriteLine($"You produce {Math.Abs(100 - (total / onePrecentage)):f2} percent less biscuits.");

            }
        }
    }
}
