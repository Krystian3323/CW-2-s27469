using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            Ship ship = new Ship("Edward", 2000, 40, 250);
            Container c1 = new LiquidContainer(30, 23, 233, 32, 23123, "Ardrestia", false);
            Container c2 = new GasContainer(20, 23, 233, 32, 3232,"Kimo", 323);
            Container c3 = new ColdContainer(15,23,232,32,312312,"Lofi", 23);

            ship.LoadContainer(c1);
            ship.LoadContainer(c2);
            ship.LoadContainer(c3);

            Console.WriteLine("Kontenery załadowane na statek.");
        }
    }
}
