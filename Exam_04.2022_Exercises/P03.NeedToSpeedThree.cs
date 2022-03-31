using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.NeedToSpeedThree
{
    class Car
    {
        public Car(string carName, int mileage, int fuel)
        {
            this.CarName = carName;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }

        public string CarName { get; set; }

        public int Mileage { get; set; }

        public int Fuel { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> carsList = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] dataArr = Console.ReadLine()
                    .Split('|', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string carName = dataArr[0];
                int mileage = int.Parse(dataArr[1]);
                int fuel = int.Parse(dataArr[2]);
                Car newCar = new Car(carName, mileage, fuel);
                carsList.Add(newCar);
            }

            while (true)
            {
                string command = Console.ReadLine();
                string[] cmdArr = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (cmdArr[0] == "Stop")
                {
                    break;
                }
                else if (cmdArr[0] == "Drive")
                {
                    string carName = cmdArr[1];
                    int distance = int.Parse(cmdArr[2]);
                    int fuel = int.Parse(cmdArr[3]);

                    GetDrive(carsList, carName, distance, fuel);
                }
                else if (cmdArr[0] == "Refuel")
                {
                    string carName = cmdArr[1];
                    int fuel = int.Parse(cmdArr[2]);

                    GetRefuelCar(carsList, carName, fuel);

                }
                else if (cmdArr[0] == "Revert")
                {
                    string carName = cmdArr[1];
                    int kilometers = int.Parse(cmdArr[2]);

                    GetRevertMileage(carsList, carName, kilometers);
                }
            }

            List<Car> printList = carsList.OrderByDescending(x => x.Mileage).ThenBy(x => x.CarName).ToList();
            foreach (var item in printList)
            {
                Console.WriteLine($"{item.CarName} -> Mileage: {item.Mileage} kms, Fuel in the tank: {item.Fuel} lt.");
            }

        }



        static void GetDrive(List<Car> carsList, string carName, int distance, int fuel)
        {
            if (carsList.Any(x => x.CarName == carName))
            {
                Car currentCar = carsList.First(x => x.CarName == carName);
                if (currentCar.Fuel >= fuel)
                {
                    Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    currentCar.Fuel -= fuel;
                    currentCar.Mileage += distance;
                    if (currentCar.Mileage >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {carName}!");
                        carsList.Remove(currentCar);                       //  ?????????? is work ???
                    }
                }
                else
                {
                    Console.WriteLine("Not enough fuel to make that ride");
                }
            }
        }



        static void GetRefuelCar(List<Car> carsList, string carsName, int fuel)
        {
            if (carsList.Any(x => x.CarName == carsName))
            {
                Car currentCar = carsList.First(x => x.CarName == carsName);
                if (currentCar.Fuel + fuel <= 75)
                {
                    currentCar.Fuel += fuel;
                    Console.WriteLine($"{carsName} refueled with {fuel} liters");
                }
                else
                {
                    int difference = 75 - currentCar.Fuel;
                    currentCar.Fuel = 75;
                    Console.WriteLine($"{carsName} refueled with {difference} liters");
                }
            }
        }



        static void GetRevertMileage(List<Car> carsList, string carName, int kilometers)
        {
            if (carsList.Any(x => x.CarName == carName))
            {
                Car currentCar = carsList.First(x => x.CarName == carName);
                currentCar.Mileage -= kilometers;
                if (currentCar.Mileage < 10000)
                {
                    currentCar.Mileage = 10000;
                }
                else
                {
                    Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");

                }
            }
        }


    }
}
