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

        public int Watt
        {
            get { return watt; }
            set
            {
                if (value < 100 || value > 30000 )
                {
                    throw new ArgumentException("Watt has to be between 100 and 30000"
                        , nameof(value));
                }
                watt = value;
            }
        }

        public ElectricScooter(string brand, string model, int year, double weight, int watt) : base(brand, model, year, weight)
        {
            Watt = watt;
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
