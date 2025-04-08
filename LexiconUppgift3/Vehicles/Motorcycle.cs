using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles
{
    class Motorcycle : Vehicle
    {

        public Motorcycle(string brand, string model, int year, double weight) : base(brand, model, year, weight)
        {
        }

        public override void StartEngine()
        {
            Console.WriteLine("EHEHEHEHEHEHE Blublublublublublublublublu...");
        }
    }
}
