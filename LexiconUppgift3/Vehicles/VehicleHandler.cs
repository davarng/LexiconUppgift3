using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles;

static class VehicleHandler
{
    //Prints all vehicles.
    public static void PrintList(List<Vehicle> vehicleList)
    {
        if (vehicleList.Any()) //Checks if there is anything in the list.
        {
            int i = 1; //Iterator since i want to print out the vehicle number in list.
            foreach (Vehicle vehicle in vehicleList)
            {
                Console.WriteLine($"Vehicle #{i}");
                vehicle.Stats();
                i++;
                Console.WriteLine("-------------------");
            }
        }
        else //Tell the user that no vehicles exist.
            Console.WriteLine("No vehicles exist at this moment.");
    }

    //Prints all vehicles info, starts the engine and tries to clean the vehicle.
    public static void RunDiagnostics(List<Vehicle> vehicleList)
    {
        if (vehicleList.Any()) //Check if vehicles exist.
        {
            foreach (Vehicle vehicle in vehicleList)
            {
                vehicle.Stats();
                vehicle.StartEngine();
                //Checks if the current vehicle is implementing the interface ICleanable.
                if (vehicle is ICleanable cleanable)
                    cleanable.Clean();
                Console.WriteLine("-------------------");
            }
        }
        else
            Console.WriteLine("No Cars exist to run diagnostics on.");
    }

    //Lets user edit a chosen vehicle.
    public static void ChangeVehicle(List<Vehicle> vehicleList)
    {   
        //Show user the list of vehicles and asks for the number of the vehicle they want to change.
        PrintList(vehicleList);
        Console.Write("Write number of vehicle: ");
        int vehicleChoice = int.Parse(Console.ReadLine());
        
        //Create vehicle copy and display info for the user.
        Vehicle vehicle = vehicleList[vehicleChoice - 1];
        Console.Clear();
        vehicle.Stats();
        //Getting the type of the vehicle.
        string vehicleType = vehicle.GetType().Name;
        
        //Informing user about how the editing works.
        //Running a method with the parameters VehicleType(So that the right method knows what properties to ask for) and a copy of vehicle.
        //Then returning the value to the list. I had some issues here but managed to make it work.
        Console.WriteLine(Environment.NewLine + "Just hit enter if you do not wish to edit field.");
        vehicleList[vehicleChoice - 1] = AssignVehicleProperties(vehicleType, vehicle);
    }

    //Creates a vehicle with the users inputs.
    public static Vehicle CreateVehicle()
    {
        //Get vehicle type and assign vehicle to null so that it can be passed into the AssignVehicleProperties method.
        string vehicleType = AskForVehicleType();
        Vehicle vehicle = null;
        Console.Clear();
        //Returns the created vehicle to the list.
        return AssignVehicleProperties(vehicleType, vehicle);
    }

    //This method helps the user give inputs both for editing and creating vehicles.
    //It took some time to make this work and I know that it's very bloated.
    private static Vehicle AssignVehicleProperties(string vehicleType, Vehicle vehicle)
    {
        //Taking the info from the user.
        Console.Write("Write brand name: ");
        string brand = Console.ReadLine();
        Console.Write("Write model name: ");
        string model = Console.ReadLine();
        //Ended up creating a string first so that I could check if the value "" is given.
        //I tried with just a TryParse but it couldn't differentiate between "" and for example "rgrdawd".
        Console.Write("Write year: ");
        string yearString = Console.ReadLine();
        bool yearExists = int.TryParse(yearString, out int year);

        Console.Write("Write weight(kg): ");
        string weightString = Console.ReadLine();
        bool weightExists = double.TryParse(weightString, out double weight);

        //The vehicle is null at this point when creating a vehicle. So this code will only run when editing.
        //Giving "" as a value makes the property not update.
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

        //Different ways of creating different types because of the unique values.
        //I'm sure there's a smoother way of doing this but I started running out of time so I just tried to make it work.
        switch (vehicleType)
        {
            case "Car":
                Console.Write("Spare tire(Y/N): ");
                answer = Console.ReadLine().ToUpper();

                //Checks if the user wanted a spare tire or not.
                if (answer == "Y")
                    vehicle = new Car(brand, model, year, weight, true);
                else if (answer == "N")
                    vehicle = new Car(brand, model, year, weight, false);
                //If the answer is "" and vehicle isn't null(Only when editing) the spareTire doesn't get edited. 
                else if (answer == "" && vehicle != null)
                    vehicle = new Car(brand, model, year, weight, (vehicle as Car).SpareTire);
                else
                    //Could't create a vehicle and get an exception on the bool spareTire because of compile errors.
                    //Made this run instead on input that's not valid.
                    throw new ArgumentException("Spare tire value must be either Y or N");

                break;
            case "ElectricScooter":
                Console.Write("Write number of Watts: ");
                answer = Console.ReadLine();

                if (answer == "" && vehicle != null)
                    vehicle = new ElectricScooter(brand, model, year, weight, (vehicle as ElectricScooter).Watt);
                else
                    vehicle = new ElectricScooter(brand, model, year, weight, int.Parse(answer));

                break;
            case "Motorcycle":
                Console.Write("Write number of wheelies: ");
                answer = Console.ReadLine();

                if (answer == "" && vehicle != null)
                    vehicle = new Motorcycle(brand, model, year, weight, (vehicle as Motorcycle).WheelieCount);
                else
                    vehicle = new Motorcycle(brand, model, year, weight, int.Parse(answer));

                break;
            case "Truck":
                Console.Write("Write number of wheels: ");
                answer = Console.ReadLine();

                if (answer == "" && vehicle != null)
                    vehicle = new Truck(brand, model, year, weight, (vehicle as Truck).NumberOfWheels);
                else
                    vehicle = new Truck(brand, model, year, weight, int.Parse(answer));

                break;
            default:
                //Can't really see this triggering but feels wierd not having a default case.
                throw new NullReferenceException("Something went wrong while creating your vehicle, please try again.");
        }
        //Returns the vehicle to Change/Create method.  
        return vehicle;
    }
    
    //Asks user for the vehicle type and returns it in a string.
    private static string AskForVehicleType()
    {
        Console.WriteLine(
            $"1. Car{Environment.NewLine}" +
            $"2. Electric scooter{Environment.NewLine}" +
            $"3. Motorcycle{Environment.NewLine}" +
            $"4. Truck");

        //Assigns vehicleType a value if the input is valid or throws an exception if it isn't.
        string vehicleType = Console.ReadLine() switch
        {
            "1" => "Car",
            "2" => "ElectricScooter",
            "3" => "Motorcycle",
            "4" => "Truck",
            _ => throw new ArgumentException("Vehicle type must be a number from 1 to 4, corresponding with the vehicle you want to create.")
        };
        //Returns the vehicle type.
        return vehicleType;
    }
}
