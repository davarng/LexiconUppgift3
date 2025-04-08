using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles
{
    static class VehicleHandler
    {
        public static void ChangeVehicle(List<Vehicle> vehicleList)
        {
            PrintList(vehicleList);
            Console.Write("Write number of car: ");
            int carChoice = int.Parse(Console.ReadLine());

        }
        public static void PrintList(List<Vehicle> vehicleList)
        {
            foreach (Vehicle vehicle in vehicleList)
            {
                Console.WriteLine($"{vehicle.Brand} {vehicle.Model}{Environment.NewLine}" +
                    $"Year: {vehicle.Year}{Environment.NewLine}" +
                    $"Weight: {vehicle.Weight}{Environment.NewLine}" +
                    $"--------------------------------------");
            }
        }
        public static Vehicle CreateVehicle()
        {
            Console.Write("Write brand name: ");
            string brand = Console.ReadLine();
            Console.Write("Write model name: ");
            string model = Console.ReadLine();
            Console.Write("Write year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Write weight: ");
            double weight = double.Parse(Console.ReadLine());

            var vehicle = new Car(brand, model, year, weight);
            return vehicle;
        }
    }
}
