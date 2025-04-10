using LexiconUppgift3.ErrorFolder;
using LexiconUppgift3.Vehicles;

namespace LexiconUppgift3;

//Frågor
//1. Det går ej. Man får ett kompilatorfel som säger "Argument 1: cannot convert from 'LexiconUppgift3.Vehicles.Car' to 'LexiconUppgift3.Vehicles.Motorcycle'"
//2. Den borde vara av typen vehicle. List<Vehicle>
//3. Om du gör en check på att fordonet på den indexplatsen du är på är av typen ICleanable så går det. Annars klagar kompilatorn på att Clean() inte finns i Vehicleklassen.
//4. Truck och Car som jag har implementerat ICleanable på ärver redan från Vehicle. I C# så kan klasser ej ärva från flera klasser.
//Därför kan man använda interfaces för att hjälpa dela egenskaper hos klasser som redan ärver.

internal class Program
{
    static void Main(string[] args)
    {
        List<Vehicle> vehicleList = new List<Vehicle>();
       
        while (true) 
        {
            Console.ResetColor();
            Console.WriteLine(
                $"1. Create vehicle{Environment.NewLine}" +
                $"2. Print all vehicles{Environment.NewLine}" +
                $"3. Change vehicle{Environment.NewLine}" +
                $"4. Print errors{Environment.NewLine}" +
                $"5. Run diagnostics on all vehicles{Environment.NewLine}" +
                $"Q. Quit application");

            string input = Console.ReadLine().ToUpper();
            Console.Clear();
            switch (input)
            {
                case "1":
                    try
                    {
                        vehicleList.Add(VehicleHandler.CreateVehicle());
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("ERROR " + e);
                    }

                    break;
                case "2":
                    VehicleHandler.PrintList(vehicleList);
                    
                    break;
                case "3":
                    VehicleHandler.ChangeVehicle(vehicleList);

                    break;
                case "4":
                    SystemError.PrintAllErrors();

                    break;
                case "5":
                    VehicleHandler.RunDiagnostics(vehicleList);

                    break;
                case "Q":

                    return;
                default:
                    Console.WriteLine("You did not choose one of the options, please try again");

                    break;
            }
        }
    }
}
