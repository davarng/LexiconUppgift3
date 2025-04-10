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
            //Removes the color from the exception messages.
            Console.ResetColor();
            Console.WriteLine(
                $"1. Create vehicle{Environment.NewLine}" +
                $"2. Print all vehicles{Environment.NewLine}" +
                $"3. Change vehicle{Environment.NewLine}" +
                $"4. Print errors{Environment.NewLine}" +
                $"5. Run diagnostics on all vehicles{Environment.NewLine}" +
                $"Q. Quit application");

            string input = Console.ReadLine().ToUpper();
            Console.Clear(); //Clearing console to make it more readable.
            switch (input)
            {
                case "1":
                    //Try catch to catch exceptions when dealing with user input. This is why i only use it on create and change.
                    try
                    {   
                        //Lets user create vehicles of different types.
                        vehicleList.Add(VehicleHandler.CreateVehicle());
                    }
                    catch (Exception e)
                    {   
                        //Making Text red for errors and printing the e.message. For regular users this should be enough.
                        //But if more detailed info is necessary you can return more than just the message.
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("ERROR " + e.Message);
                    }

                    break;
                case "2":
                    //Prints all the vehicles.
                    VehicleHandler.PrintList(vehicleList);
                    
                    break;
                case "3":
                    try
                    {
                        //Lets the user change properties of vehicles.
                        VehicleHandler.ChangeVehicle(vehicleList);
                    }
                    catch(Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("ERROR " + e.Message);
                    }

                    break;
                case "4":
                    //Printing errors.
                    SystemError.PrintAllErrors();

                    break;
                case "5":
                    //Prints all vehicle information, starts the vehicle and also attempts to clean the vehicles if they are ICleanable.
                    VehicleHandler.RunDiagnostics(vehicleList);

                    break;
                case "Q":
                    //Turns off the application.
                    return;
                default:
                    //If the user didn't give a valid value.
                    Console.WriteLine("You did not choose one of the options, please try again");

                    break;
            }
            Console.WriteLine();
        }
    }
}
