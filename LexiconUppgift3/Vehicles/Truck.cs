using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles;

class Truck : Vehicle, ICleanable
{
    private int numberOfWheels;

    public int NumberOfWheels         
    {
        get { return numberOfWheels; }
        set
        {
            if (value < 3 || value > 30)
            {
                throw new ArgumentException("Number of wheels has to be greater than 3 but less than 30"
                    , nameof(value));
            }
            numberOfWheels = value;
        }
    }
    public Truck(string brand, string model, int year, double weight, int numberOfWheels) : base(brand, model, year, weight)
    {
        NumberOfWheels = numberOfWheels;
    }

    public void Clean()
    {
        Console.WriteLine($"{Environment.NewLine}Cleaning Truck.");
    }

    public override void StartEngine()
    {
        Console.WriteLine($"{Environment.NewLine}Starting motor: EHEHE WROOM WROOOOOM WROOOOM");
    }

    public override void Stats()
    {
        base.Stats();
        Console.WriteLine($"Number of wheels: {NumberOfWheels}");
    }
}
