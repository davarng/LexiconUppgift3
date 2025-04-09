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
                    throw new ArgumentException("Number of wheelies has to be greater than 0"
                        , nameof(value));
                }
                wheelieCount = value;
            }
        }

        public Motorcycle(string brand, string model, int year, double weight, int wheelieCount) : base(brand, model, year, weight)
        {
            WheelieCount = wheelieCount;
        }

        public override void StartEngine()
        {
            Console.WriteLine("EHEHEHEHEHEHE Blublublublublublublublublu...");
        }
    }
}
