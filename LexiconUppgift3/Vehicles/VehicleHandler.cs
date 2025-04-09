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
        //public static Vehicle CreateVehicle(string input)
        //{
        //    Console.WriteLine(
        //        $"1. Car{Environment.NewLine}" +
        //        $"2. Electric scooter{Environment.NewLine}" +
        //        $"3. Motorcycle{Environment.NewLine}" +
        //        $"4. Truck");

        //    Console.Write("Write brand name: ");
        //    string brand = Console.ReadLine();
        //    Console.Write("Write model name: ");
        //    string model = Console.ReadLine();
        //    Console.Write("Write year: ");
        //    int year = int.Parse(Console.ReadLine());
        //    Console.Write("Write weight: ");
        //    double weight = double.Parse(Console.ReadLine());
        //    Vehicle vehicle;

        //    string answer;
        //    switch (input)
        //    {
        //        case "1":
        //            Console.WriteLine("Spare tire(Y/N): ");
        //            answer = Console.ReadLine().ToUpper();
        //            if (answer == "Y")
        //                vehicle = new Car(brand,model,year,weight,true);
        //            else if (answer == "N")
        //                vehicle = new Car(brand, model, year, weight, false);

        //            break;
        //        case "2":
        //            Console.WriteLine("Write number of Watts: ");
        //            answer = Console.ReadLine().ToUpper();
        //            vehicle = new ElectricScooter(brand, model, year, weight, int.Parse(answer));

        //            break;
        //        case "3":
        //            Console.WriteLine("Write number of wheelies: ");
        //            answer = Console.ReadLine().ToUpper();
        //            vehicle = new ElectricScooter(brand, model, year, weight, int.Parse(answer));

        //            break;
        //        case "4":
        //            Console.WriteLine("Write number of wheels: ");
        //            answer = Console.ReadLine().ToUpper();
        //            vehicle = new ElectricScooter(brand, model, year, weight, int.Parse(answer));

        //            break;
        //    }

        //    return vehicle;
        //}
    }
}
