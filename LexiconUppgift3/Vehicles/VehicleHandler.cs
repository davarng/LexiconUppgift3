using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles
{
    static class VehicleHandler
    {
        public static void PrintList(List<Vehicle> vehicleList)
        {
            if (vehicleList.Any())
            {
                int i = 1;
                foreach (Vehicle vehicle in vehicleList)
                {
                    Console.WriteLine($"Vehicle #{i}");
                    vehicle.Stats();
                    i++;
                }
            }
            else
                Console.WriteLine("No cars exist at this moment.");
        }

        public static void RunDiagnostics(List<Vehicle> vehicleList)
        {
            if (vehicleList.Any())
            {
                foreach (Vehicle vehicle in vehicleList)
                {
                    vehicle.Stats();
                    vehicle.StartEngine();
                    if (vehicle is ICleanable cleanable)
                        cleanable.Clean();
                    Console.WriteLine("-------------------");
                }
            }
            else
                Console.WriteLine("No Cars exist to run diagnostics on.");
        }

        public static void ChangeVehicle(List<Vehicle> vehicleList)
        {
            PrintList(vehicleList);
            Console.Write("Write number of vehicle: ");
            int vehicleChoice = int.Parse(Console.ReadLine());
            
            Vehicle vehicle = vehicleList[vehicleChoice - 1];
            Console.Clear();
            vehicle.Stats();
            
            string vehicleType = vehicle.GetType().Name;

            Console.WriteLine("Just hit enter if you do not wish to edit field.");
            vehicleList[vehicleChoice - 1] = AssignVehicleProperties(vehicleType, vehicle);
        }

        public static Vehicle CreateVehicle()
        {
            string vehicleType = AskForVehicleType();
            Vehicle vehicle = null;

            return AssignVehicleProperties(vehicleType, vehicle);
        }

        private static Vehicle AssignVehicleProperties(string vehicleType, Vehicle vehicle)
        {
            Console.Write("Write brand name: ");
            string brand = Console.ReadLine();
            Console.Write("Write model name: ");
            string model = Console.ReadLine();

            Console.Write("Write year: ");
            string yearString = Console.ReadLine();
            bool yearExists = int.TryParse(yearString, out int year);

            Console.Write("Write weight: ");
            string weightString = Console.ReadLine();
            bool weightExists = double.TryParse(weightString, out double weight);

            if (vehicle != null)
            {
                if (brand == "")
                    brand = vehicle.Brand;
                if (model == "")
                    model = vehicle.Model;
                if (yearString == "")
                    year = vehicle.Year;
                if (weightString == "")
                    weight = vehicle.Weight;
            }

            string answer;

            switch (vehicleType)
            {
                case "Car":
                    Console.WriteLine("Spare tire(Y/N): ");
                    answer = Console.ReadLine().ToUpper();

                    if (answer == "Y")
                        vehicle = new Car(brand, model, year, weight, true);
                    else if (answer == "N")
                        vehicle = new Car(brand, model, year, weight, false);
                    else if (answer == "" && vehicle != null)
                    {
                        vehicle = new Car(brand, model, year, weight, (vehicle as Car).SpareTire);
                    }

                    break;
                case "ElectricScooter":
                    Console.WriteLine("Write number of Watts: ");
                    answer = Console.ReadLine();

                    if (answer == "" && vehicle != null)
                        vehicle = new ElectricScooter(brand, model, year, weight, (vehicle as ElectricScooter).Watt);
                    else
                        vehicle = new ElectricScooter(brand, model, year, weight, int.Parse(answer));

                    break;
                case "Motorcycle":
                    Console.WriteLine("Write number of wheelies: ");
                    answer = Console.ReadLine();

                    if (answer == "" && vehicle != null)
                        vehicle = new Motorcycle(brand, model, year, weight, (vehicle as Motorcycle).WheelieCount);
                    else
                        vehicle = new Motorcycle(brand, model, year, weight, int.Parse(answer));

                    break;
                case "Truck":
                    Console.WriteLine("Write number of wheels: ");
                    answer = Console.ReadLine();

                    if (answer == "" && vehicle != null)
                        vehicle = new Truck(brand, model, year, weight, (vehicle as Truck).NumberOfWheels);
                    else
                        vehicle = new Truck(brand, model, year, weight, int.Parse(answer));

                    break;
                default:
                    throw new NullReferenceException("Something went wrong while creating your vehicle, please try again.");
            }

            if (vehicle != null)
                return vehicle;
            else
                throw new ArgumentException("The input you gave is not valid");
        }

        private static string AskForVehicleType()
        {
            Console.WriteLine(
                $"1. Car{Environment.NewLine}" +
                $"2. Electric scooter{Environment.NewLine}" +
                $"3. Motorcycle{Environment.NewLine}" +
                $"4. Truck");

            string answer = Console.ReadLine() switch 
            {
                 "1" => "Car",
                 "2" => "ElectricScooter",
                 "3" => "Motorcycle",
                 "4" => "Truck",
                 _ => "NoType" 
            };

            return answer;
        }
    }
}
