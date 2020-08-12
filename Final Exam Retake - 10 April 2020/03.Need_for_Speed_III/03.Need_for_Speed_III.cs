using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int> carMileage = new Dictionary<string, int>();
        Dictionary<string, int> carFuel = new Dictionary<string, int>();

        int numberOFCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOFCars; i++)
        {
            string[] carInfo = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

            string car = carInfo[0];
            int mileage = int.Parse(carInfo[1]);
            int fuel = int.Parse(carInfo[2]);
            if (!carMileage.ContainsKey(car))
            {
                carMileage[car] = mileage;
                carFuel[car] = fuel;
            }
        }

        string input = "";
        while ((input = Console.ReadLine()) != "Stop")
        {
            string[] tokens = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            string car = tokens[1];
            switch (command)
            {
                case "Drive":
                    int distance = int.Parse(tokens[2]);
                    int fuel = int.Parse(tokens[3]);
                    if (fuel > carFuel[car])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carMileage[car] += distance;
                        carFuel[car] -= fuel;
                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (carMileage[car] >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        carMileage.Remove(car);
                        carFuel.Remove(car);
                    }
                    break;
                case "Refuel":
                    fuel = int.Parse(tokens[2]);
                    int refilled = 0;
                    int original = carFuel[car];
                    carFuel[car] += fuel;
                    refilled = fuel;
                    if (carFuel[car] > 75)
                    {
                        carFuel[car] = 75;
                        refilled = carFuel[car] - original;
                    }
                    Console.WriteLine($"{car} refueled with {refilled} liters");
                    break;
                case "Revert":
                    int kilometers = int.Parse(tokens[2]);
                    carMileage[car] -= kilometers;
                    if (carMileage[car] < 10000)
                    {
                        carMileage[car] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{car} mileage decreased by {kilometers} kilometers");
                    }
                    break;
            }
        }

        foreach (var kvp in carMileage
            .OrderByDescending(x => x.Value)
            .ThenBy(x=>x.Key))
        {
            Console.WriteLine($"{kvp.Key} -> Mileage: {kvp.Value} kms, Fuel in the tank: {carFuel[kvp.Key]} lt.");
        }
    }
}

