using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShipClassLibrary
{
    public class ContainerShip
    {
        private List<int> cargoWeights;
        private int weightCurrentCrate;
        private readonly int maxLiftingCapacity;

        /// <summary>
        /// Initializing Variables
        /// </summary>
        /// <param name="max">Maximum lifting capacity</param>
        public ContainerShip(int max)
        {
            maxLiftingCapacity = max;
            cargoWeights = new List<int>();
        }

        /// <summary>
        /// Warning!!! - This function can reproduce an exception.
        /// 
        /// Read cargo weights from the file.
        /// and add them to the `cargoWeights` list.
        /// 
        /// Reads each line line by line. 
        /// Checks if a `line` is an integer, positive. 
        /// If so, it is added to the `cargoWeights` list.
        /// </summary>
        /// <param name="path">The path to the file</param>
        public void TryReadAddCargoWeights(string path)
        {
            var lines = File.ReadLines(path);
            foreach (var line in lines)
            {
                var isInt = int.TryParse(line, out weightCurrentCrate);
                if (isInt && weightCurrentCrate > 0)
                    cargoWeights.Add(weightCurrentCrate);
            }
        }

        /// <summary>
        /// Takes the masses of the maximum
        /// possible cargo to the carrier.
        /// </summary>
        /// <returns>List of possible masses</returns>
        public List<int> TakeMaxAmountCrates()
        {
            var result = new List<int>();
            cargoWeights.Sort();
            TakeLowestItems(result, maxLiftingCapacity);
            return result;
        }

        /// <summary>
        /// Takes masses from the `cargoWeights` list 
        /// until now, until `max` becomes negative.
        /// </summary>
        /// <param name="result">List with suitable weights</param>
        /// <param name="max">Maximum lifting capacity</param>
        private void TakeLowestItems(List<int> result, int max)
        {
            for (int i = 0; i < cargoWeights.Count(); i++)
            {
                if (max - cargoWeights[i] >= 0)
                {
                    max -= cargoWeights[i];
                    result.Add(cargoWeights[i]);
                }
                else
                    break;
            }
        }
    }
}
