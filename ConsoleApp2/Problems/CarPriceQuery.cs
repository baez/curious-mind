
namespace problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using models;

    public class CarPriceQuery
    {
        public Car MostExpensiveCar(List<Car> cars)
        {
            if (cars == null || !cars.Any())
            {
                throw new ArgumentException("There are no cars.");
            }

            var mostExpensiveCar = cars.OrderBy(c => c.Price).Last();

            return mostExpensiveCar;
        }

        public Car CheapestCar(List<Car> cars)
        {
            if (cars == null || !cars.Any())
            {
                throw new ArgumentException("There are no cars.");
            }

            var cheapestCar = cars.OrderBy(c => c.Price).First();

            return cheapestCar;
        }

        public int AveragePriceOfCars(List<Car> cars)
        {
            if (cars == null || !cars.Any())
            {
                throw new ArgumentException("There are no cars.");
            }

            var sum = cars.Sum(s => s.Price);
            decimal averagePriceDecimal = sum / cars.Count;

            int averagePrice = (int)Math.Round(averagePriceDecimal + (decimal)0.5);

            return averagePrice;
        }

        public Dictionary<string, Car> MostExpensiveModelForEachBrand(List<Car> cars)
        {
            if (cars == null || !cars.Any())
            {
                throw new ArgumentException("There are no cars.");
            }

            var mostExpensiveCarInBrands = new Dictionary<string, Car>();
            var orderedCars = cars.OrderBy(c => c.Price);

            foreach (var car in orderedCars)
            {
                if (mostExpensiveCarInBrands.TryGetValue(car.Brand, out Car foundCar))
                {
                    if (foundCar.Price < car.Price)
                    {
                        mostExpensiveCarInBrands[foundCar.Brand] = car;
                    }
                }
                else
                {
                    mostExpensiveCarInBrands.Add(car.Brand, car);
                }
            }
            
            return mostExpensiveCarInBrands;
            
        }
    }
}