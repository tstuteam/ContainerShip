using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ContainerShipClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ContainerShipConsoleUnitTest
{
    [TestClass]
    public class ContainerShipTest
    {
        /// <summary>
        /// All strings are integers.
        /// </summary>
        [TestMethod]
        public void Ship_ValidFile_ValidData()
        {
            var ship = new ContainerShip(100);
            /*
             File C:\Temp\data.txt with content:
                50
                70
                60
                123
                42
                5
             */
            ship.TryReadAddCargoWeights(@"C:\Temp\data.txt");

            Assert.IsTrue(IsEqual(ship.TakeMaxAmountCrates(),
                new List<int>() { 5, 42, 50 }));
        }

        /// <summary>
        /// Empty file, no content.
        /// </summary>
        [TestMethod]
        public void Ship_EmptyFile()
        {
            var ship = new ContainerShip(100);
            /*
             File C:\Temp\empty.txt with no content.
             */
            ship.TryReadAddCargoWeights(@"C:\Temp\empty.txt");

            Assert.IsTrue(IsEqual(ship.TakeMaxAmountCrates(),
                new List<int>() { }));
        }

        /// <summary>
        /// File consisting entirely of inappropriate data.
        /// </summary>
        [TestMethod]
        public void Ship_ValidFile_InvalidData()
        {
            var ship = new ContainerShip(100);
            /*
             File C:\Temp\invalid.txt with content:
                0
                0
                0
             */
            ship.TryReadAddCargoWeights(@"C:\Temp\empty.txt");

            Assert.IsTrue(IsEqual(ship.TakeMaxAmountCrates(),
                new List<int>() { }));
        }

        /// <summary>
        /// Partially correct data file.
        /// </summary>
        [TestMethod]
        public void Ship_ValidFile_PartitialValidData()
        {
            var ship = new ContainerShip(100);
            /*
             With content:
                asdas
                fas
                asf
                152
                32
                asd
                2.12
                124
                asf
                21
                -124
                0
                -12
                421.2
                asd
                124
                asfqt
             */
            ship.TryReadAddCargoWeights(@"C:\Temp\str.txt");

            Assert.IsTrue(IsEqual(ship.TakeMaxAmountCrates(),
                new List<int>() { 21, 32 }));
        }

        /// <summary>
        /// No file.
        /// Exception thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Ship_NotFoundFile()
        {
            var ship = new ContainerShip(100);
            ship.TryReadAddCargoWeights(@"C:\Temp\null.txt");
        }

        /// <summary>
        /// Tests the strict equality of two lists
        /// by checking each element for equality.
        /// </summary>
        /// <param name="list1">First list</param>
        /// <param name="list2">Second list</param>
        /// <returns>Result of testing</returns>
        private bool IsEqual(List<int> list1, List<int> list2)
        {
            for (int i = 0; i < list1.Count(); i++)
                if (list1[i] != list2[i])
                    return false;
            return true;
        }
    }
}
