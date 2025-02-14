using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using models;
using problems;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("===== Test from ConsoleApp2 -- hello :D =====");

        if (args.Length == 0)
        {
            throw new ArgumentException("Error: Please pass in the filename containing Car data as a command line argument.");
        }

        TestCarQueries(args[0]);
    }

    public static void TestCarQueries(string filename) 
    {    
        var lines = File.ReadLines(filename).ToArray();

        var cars = new List<Car>(); 
        Console.WriteLine($"Reading data from {filename}");

        foreach (string line in lines) 
        { 
            string[] strArr = line.Split(' '); 
            cars.Add(new Car {  
                Brand = strArr[0],  
                Model = strArr[1],  
                Price = int.Parse(strArr[2])  
                });
            
            Console.WriteLine($"{strArr[0]}, {strArr[1]}, {strArr[2]}"); 
        }

        var carQuery = new CarPriceQuery();

        var mostExpensiveCar = carQuery.MostExpensiveCar(cars); 
        Console.WriteLine($"The most expensive car is {mostExpensiveCar.Brand} {mostExpensiveCar.Model}"); 
        var cheapestCar = carQuery.CheapestCar(cars); 

        Console.WriteLine($"The cheapest car is {cheapestCar.Brand} {cheapestCar.Model}"); 
        Console.WriteLine($"The average price of all cars is {carQuery.AveragePriceOfCars(cars)}"); 

        foreach (var res in carQuery.MostExpensiveModelForEachBrand(cars)) 
        { 
            Console.WriteLine($"The most expensive model for brand {res.Key} is {res.Value.Model} having price {res.Value.Price}"); 
        } 
    }  
}