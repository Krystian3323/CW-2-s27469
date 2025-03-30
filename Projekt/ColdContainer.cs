using System;
using System.Collections.Generic;

namespace Projekt
{
    public class ColdContainer : Container
    {
        public double Temperature { get; private set; }
        private Dictionary<string, double> productTemperatureRequirements;

        public ColdContainer(double loadWeight, double height, double selfWeight, double depth, double maxWeight, string containerType, double temperature)
            : base(loadWeight, height, selfWeight, depth, maxWeight, containerType)
        {
            Temperature = temperature;
            productTemperatureRequirements = new Dictionary<string, double>
            {
                { "Bananas", 13.3 },
                { "Chocolate", 18 },
                { "Fish", 2 },
                { "Meat", -15 },
                { "Ice cream", -18 },
                { "Frozen pizza", -30 },
                { "Cheese", 7.2 },
                { "Sausages", 5 },
                { "Butter", 20.5 },
                { "Eggs", 19 }
            };
        }

        public bool CanStoreProduct(string productName)
        {
            if (productTemperatureRequirements.TryGetValue(productName, out double requiredTemperature))
            {
                return Temperature >= requiredTemperature;
            }
            else
            {
                throw new ArgumentException("Unknown product.");
            }
        }
    }
}
