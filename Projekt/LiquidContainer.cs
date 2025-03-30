using System;

namespace Projekt
{
    internal class LiquidContainer : Container, IHazardNotifier
    {
        public bool IsHazardous { get; set; }

        private HazardNotifier hazardNotifier = new HazardNotifier();

        public LiquidContainer(double loadWeight, double height, double selfWeight, double depth, double maxWeight, string containerType, bool isHazardous)
            : base(loadWeight, height, selfWeight, depth, maxWeight, containerType)
        {
            IsHazardous = isHazardous;
        }

        public override void Load(double weight)
        {
            double safeLimit = IsHazardous ? 0.5 * MaxWeight : 0.9 * MaxWeight;

            if (LoadWeight + weight > safeLimit)
            {
                hazardNotifier.NotifyHazard(IsHazardous, SerialNumber);
                Console.WriteLine($"Nie można załadować więcej niż {safeLimit} kg dla tego kontenera.");
            }
            else
            {
                LoadWeight += weight;
            }
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