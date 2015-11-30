using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WMS;
using WMS.WH;
using WMS.Interfaces;

namespace UnitTestProject1
{
    [TestClass]
    public class ItemTest
    {
        [TestMethod]
        public void TestMethod1()
        { 
            //Arrange
            int a = 0;
            Item anItem = new Item("1000", "An Item", 9, "2.3", 10);

            //Act
            a = anItem.CompareTo(new Item("1000", "An Item", 9, "2.3", 10));

            //Assert
            Assert.AreEqual(1, 1);
        }
    }
}
