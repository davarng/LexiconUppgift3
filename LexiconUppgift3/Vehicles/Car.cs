using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles
{
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
            Console.WriteLine("UHUHUHU brum brum brum");
        }

        public void Clean()
        {
            Console.WriteLine($"Cleaning car.");
        }

        public override void Stats()
        {
            base.Stats();
            Console.WriteLine($"Spare tire: {(SpareTire ? "Yes":"No")}");
        }
    }
}
