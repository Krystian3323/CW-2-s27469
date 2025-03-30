using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Container
    {
        public double LoadWeight { get; set; } // w kilogramach
        public double Height { get; set; } // w centymetrach
        public double SelfWeight { get; set; } // w kilogramach
        public double Depth { get; set; } // w centymetrach
        public double MaxWeight { get; set; } // w kilogramach
        public string SerialNumber { get; private set; } // Unikalny numer seryjny

        private static int SerialCounter = 1; // Numer startowy
        private static List<string> ListSerialNumbers = new List<string>(); // Lista numerów seryjnych

        public Container(string containerType)
        {
            SerialNumber = GenerateUniqueSerial(containerType);
        }

        private string GenerateUniqueSerial(string containerType)
        {
            string number;
            do
            {
                number = $"KON-{containerType}-{SerialCounter}";
                SerialCounter++;
            } while (ListSerialNumbers.Contains(number));

            ListSerialNumbers.Add(number);
            return number;
        }

        public Container(double loadWeight, double height, double selfWeight, double depth, double maxWeight, string containerType)
        {
            LoadWeight = loadWeight;
            Height = height;
            SelfWeight = selfWeight;
            Depth = depth;
            MaxWeight = maxWeight;
            SerialNumber = GenerateUniqueSerial(containerType);
        }

        public virtual void Unload()    // virtula do przysloneicia potem
        {
            LoadWeight = 0;
        }

        public virtual void Load(double weight)
        {
            if (LoadWeight + weight > MaxWeight)
            {
                Console.WriteLine("You cannot load that much. Max load passed !");
            }
            else
            {
                LoadWeight += weight;
            }
        }
    }
}
