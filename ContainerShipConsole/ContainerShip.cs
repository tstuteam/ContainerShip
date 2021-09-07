using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShipConsole
{
    public class ContainerShip
    {
        

        static void Main(string[] args)
        {
            var ship = new ContainerShip(100);
            ship.TryReadAddCargoWeights(@"C:\Temp\str.txt");
            ship.TakeMaxAmountCrates().ForEach(x => Console.WriteLine(x));
        }
    }
}
