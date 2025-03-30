using System;
using System.Collections.Generic;

namespace Projekt
{
    public class Ship
    {
        public string Name { get; set; } // zwykla nazwa 
        public double MaxSpeed { get; set; } // węzłach
        public int MaxContainers { get; set; } // maksymalna ich liczba naraz
        public double MaxWeight { get; set; } // w tonach 
        public List<Container> Containers { get; private set; }  // lista jak w przypadku numerow seryjnych

        public Ship(string name, double maxSpeed, int maxContainers, double maxWeight)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            MaxWeight = maxWeight;
            Containers = new List<Container>();
        }

        public bool LoadContainer(Container container)
        {
            if (Containers.Count >= MaxContainers)
            {
                Console.WriteLine("Cannot load: Maximum container capacity reached.");
                return false;
            }
            if (GetTotalWeight() + container.LoadWeight > MaxWeight)
            {
                Console.WriteLine("Cannot load: Exceeds maximum weight capacity.");
                return false;
            }
            Containers.Add(container);
            return true;
        }

        public bool UnloadContainer(string serialNumber)
        {
            Container container = Containers.Find(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                Containers.Remove(container);
                return true;
            }
            Console.WriteLine("Container not found.");
            return false;
        }

        public void TransferContainer(Ship targetShip, string serialNumber)
        {
            Container container = Containers.Find(c => c.SerialNumber == serialNumber);
            if (container != null && targetShip.LoadContainer(container))
            {
                Containers.Remove(container);
            }
        }

        public double GetTotalWeight()
        {
            double totalWeight = 0;
            foreach (var container in Containers)
            {
                totalWeight += container.LoadWeight;
            }
            return totalWeight;
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Ship: {Name}, Max Speed: {MaxSpeed} knots, Max Containers: {MaxContainers}, Max Weight: {MaxWeight} tons");
            Console.WriteLine($"Current Load: {Containers.Count} containers, Total Weight: {GetTotalWeight()} tons");
        }
    }
}

