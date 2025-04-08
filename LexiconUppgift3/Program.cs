using LexiconUppgift3.ErrorFolder;
using LexiconUppgift3.Vehicles;

namespace LexiconUppgift3;

internal class Program
{
    //Frågor
    //1. Det går ej. Man får ett kompilatorfel som säger "Argument 1: cannot convert from 'LexiconUppgift3.Vehicles.Car' to 'LexiconUppgift3.Vehicles.Motorcycle'"
    //2. Den borde vara av typen vehicle. List<Vehicle>
    //3. 
    static void Main(string[] args)
    {
        List<Vehicle> list = new List<Vehicle>();
        Car car = new Car("toyota","yaris",1998,1400.0);
        Truck truck = new Truck("toyota", "pickup", 1988, 3000.0);
        list.Add(car);
        list.Add(truck);
        list[0].Clean();


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
