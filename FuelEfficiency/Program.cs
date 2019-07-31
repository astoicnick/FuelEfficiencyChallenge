using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelEfficiency
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cars = GetCars("fuel.csv");
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }
            Console.ReadLine();
        }

        private static List<Car> GetCars(string path)
        {
            return
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Car.ParseFromCsv)
                .OrderByDescending(c => c.Combined)
                .Take(10)
                .ToList();
        }

    }
}
