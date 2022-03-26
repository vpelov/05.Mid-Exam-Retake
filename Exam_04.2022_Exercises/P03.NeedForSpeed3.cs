using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.NeedForSpeed3
{
    class Cars
    {
        public Cars(string car, int mileage, int fuel)
        {
            this.Car = car;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string Car { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Cars> carsList = new List<Cars>();

            int numberCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberCars; i++)
            {
                string[] carsData = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string car = carsData[0];
                int mileage = int.Parse(carsData[1]);
                int fuel = int.Parse(carsData[2]);

                Cars currentCars = new Cars(car, mileage, fuel);
                carsList.Add(currentCars);
            }

            string commands = Console.ReadLine();
            while (commands != "Stop")
            {
                string[] commandArray = commands
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string command = commandArray[0];

                if (command == "Drive")
                {
                    string car = commandArray[1];
                    int distance = int.Parse(commandArray[2]);
                    int fuel = int.Parse(commandArray[3]);

                    if (carsList.First(x => x.Car == car).Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        for (int i = 0; i < carsList.Count; i++)
                        {                        
                            if (carsList[i].Car == car)
                            {
                                carsList[i].Fuel -= fuel;
                                carsList[i].Mileage += distance;
                                Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                                if (carsList[i].Mileage >= 100000)
                                {
                                    carsList.Remove(carsList[i]);
                                    Console.WriteLine($"Time to sell the {car}!");
                                }
                            }
                        
                        }                        
                    }
                }
                else if (command == "Refuel")
                {
                    string car = commandArray[1];
                    int fuel = int.Parse(commandArray[2]);

                    foreach (Cars item in carsList)    
                    {
                        if (item.Car == car)
                        {


                            if (item.Fuel + fuel < 75)
                            {
                                item.Fuel += fuel;
                                Console.WriteLine($"{car} refueled with {fuel} liters");
                            }
                            else
                            {
                                item.Fuel = 75;
                                int needFuel = 75 - item.Fuel;
                                Console.WriteLine($"{car} refueled with {needFuel} liters");
                            }
                        }
                    }
                }
                else if (command == "Revert")
                {
                    string car = commandArray[1];
                    int kilometers = int.Parse(commandArray[2]);

                    foreach (Cars item in carsList)
                    {
                        if (item.Car == car)
                        {
                            if (item.Mileage - kilometers < 10000)
                            {
                                item.Mileage = 10000;
                            }
                            else
                            {
                                item.Mileage -= kilometers;
                                Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                            }
                        }
                    }


                }

                commands = Console.ReadLine();
            }

            carsList = carsList.OrderByDescending(x => x.Mileage).ThenBy(x => x.Car).ToList();


            foreach (Cars item in carsList)
            {
                Console.WriteLine($"{item.Car} -> Mileage: {item.Mileage} kms, Fuel in the tank: {item.Fuel} lt.");
            }
        }
    }
}

