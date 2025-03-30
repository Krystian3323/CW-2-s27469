using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    internal interface IHazardNotifier
    {
        void NotifyHazard(bool isHazardous, string serialNumber);
    }

    public class HazardNotifier : IHazardNotifier
    {
        public void NotifyHazard(bool isHazardous, string serialNumber)
        {
            if (isHazardous)
            {
                throw new InvalidOperationException($"Niebezpieczna sytuacja w kontenerze: {serialNumber}");
            }
        }
    }
}

