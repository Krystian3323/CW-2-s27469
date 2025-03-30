using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public  class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; set; }

        public GasContainer(double loadWeight, double height, double selfWeight, double depth, double maxWeight, string containerType, double pressure)
            : base(loadWeight, height, selfWeight, depth, maxWeight, containerType)
        {
            Pressure = pressure;
        }

        public override void Unload()
        {
            LoadWeight *= 0.05;  // pozostawiamy 0,05% calosci 
        }

        public void Load(double weight)
        {
            if (LoadWeight + weight > MaxWeight)
            {
                throw new InvalidOperationException($"Przekroczono dopuszczalną ładowność! {SerialNumber}");
            }
            LoadWeight += weight;
        }

        public void NotifyHazard(bool isHazardous, string serialNumber)
        {
            if (isHazardous)
            {
                throw new InvalidOperationException($"Niebezpieczna sytuacja w kontenerze: {serialNumber}");
            }
        }

    }
}
