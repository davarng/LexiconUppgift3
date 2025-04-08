using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles
{
    class Truck : Vehicle, ICleanable
    {
        public Truck(string brand, string model, int year, double weight) : base(brand, model, year, weight)
        {
        }

        public void Clean()
        {
            throw new NotImplementedException();
        }

        public override void StartEngine()
        {
            Console.WriteLine("EHEHE WROOM WROOOOOM WROOOOM");
        }
    }
}
