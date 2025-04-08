using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles
{
    class Motorcycle : Vehicle
    {
        private int wheelieCount;

        public int WheelieCount        
        {
            get { return wheelieCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("No negative wheelies"
                        , nameof(value));
                }
                wheelieCount = value;
            }
        }

        public Motorcycle(string brand, string model, int year, double weight) : base(brand, model, year, weight)
        {
        }

        public override void StartEngine()
        {
            Console.WriteLine("EHEHEHEHEHEHE Blublublublublublublublublu...");
        }
    }
}
