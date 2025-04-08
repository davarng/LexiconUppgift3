using LexiconUppgift3.ErrorFolder;

namespace LexiconUppgift3;

internal class Program
{
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
