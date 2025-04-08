using LexiconUppgift3.ErrorFolder;
using LexiconUppgift3.Vehicles;

namespace LexiconUppgift3;

internal class Program
{
    //Frågor
    //1. Det går ej. Man får ett kompilatorfel som säger "Argument 1: cannot convert from 'LexiconUppgift3.Vehicles.Car' to 'LexiconUppgift3.Vehicles.Motorcycle'"
    //2. Den borde vara av typen vehicle. List<Vehicle>
    //3. Nej det går ej. Clean finns ej i Vehicle. "'Vehicle' does not contain a definition for 'Clean' and no accessible extension method 'Clean' accepting a first argument of type 'Vehicle' could be found (are you missing a using directive or an assembly reference?)"
    //4. Truck och Car som jag har implementerat ICleanable på ärver redan från Vehicle. I C# så kan klasser ej ärva från flera klasser.
    //Därför kan man använda interfaces för att hjälpa dela egenskaper hos klasser som redan ärver.
    static void Main(string[] args)
    {
        List<Vehicle> vehicleList = new List<Vehicle>();
        while (true) 
        {
            Console.WriteLine(
                $"1. Create vehicle{Environment.NewLine}" +
                $"2. Print all vehicles{Environment.NewLine}" +
                $"3. Change vehicle{Environment.NewLine}" +
                $"4. Print errors{Environment.NewLine}" +
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
                    
                    EngineFailureError engineFailureError = new EngineFailureError();
                    TransmissionFailureError transmissionFailureError = new TransmissionFailureError();
                    BrakeFailureError brakeFailureError = new BrakeFailureError();
                    List<SystemError> errorList = [brakeFailureError,transmissionFailureError,engineFailureError];

                    foreach (var error in errorList)
                    {
                        Console.WriteLine(error.ErrorMessage());
                    }
                    break;
                case "Q":
                    return;
            }
            
        }
        
    }
}
