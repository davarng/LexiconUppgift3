using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles;

//Implements the interface ICleanable and so does Truck.
class Car : Vehicle, ICleanable
{
    private bool spareTire;
    public bool SpareTire
    {
        get { return spareTire; }
        set
        {
            spareTire = value;
        }
    }
    public Car(string brand, string model, int year, double weight, bool spareTire) : base(brand, model, year, weight)
    {
        SpareTire = spareTire;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"{Environment.NewLine}Starting motor: UHUHUHU brum brum brum");
    }

    //Implementing abstract method from ICleanable, same with Truck.
    public void Clean()
    {
        Console.WriteLine($"{Environment.NewLine}Cleaning car.");
    }

    public override void Stats()
    {
        //Using the base version of stats and then adding the unique property. Same for the other vehicle classes.
        base.Stats();
        Console.WriteLine($"Spare tire: {(SpareTire ? "Yes":"No")}");
    }
}
