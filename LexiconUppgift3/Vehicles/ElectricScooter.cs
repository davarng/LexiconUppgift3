using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconUppgift3.Vehicles
{
    class ElectricScooter : Vehicle
    {
        private int watt;

        public int Watt         //1886-current year
        {
            get { return watt; }
            set
            {
                if (value < 100 || value > 30000 )
                {
                    throw new ArgumentException("slow or fast"
                        , nameof(value));
                }
                watt = value;
            }
        }

        public ElectricScooter(string brand, string model, int year, double weight) : base(brand, model, year, weight)
        {
        }

        public override void StartEngine()
        {
            Console.WriteLine("*Cricket noises* Wait a second... Electric vehicles don't have engines, they have motors." + Environment.NewLine +
            "Press enter to start the motor instead.");
            Console.ReadLine();
            StartMotor();
        }
        private static void StartMotor() 
        { 
            Console.WriteLine("wuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu"); 
        }
    }
}
