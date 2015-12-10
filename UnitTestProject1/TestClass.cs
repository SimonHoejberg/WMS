using System;
using System.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WMS;
using WMS.Handlers;
using WMS.GUI;
using WMS.WH;
using WMS.Core;
using WMS.Interfaces;

namespace UnitTestWMS
{
    [TestClass]
    public class TestClass
    {

        [TestMethod]
        public void GetTimeStampTest()
        {
            //Arrange
            IMain main = new Main();
            CoreSystem Test = new CoreSystem(main);
            string expected = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            //Act
            string testValue = Test.GetTimeStamp();

            //Assert
            Assert.AreEqual(expected, testValue);
        }
        

        [TestMethod]
        public void GetDataTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            int expected = 11;

            //Act
            MySqlDataAdapter output = core.DataHandler.GetData("information");
            DataTable testValue = new DataTable();
            output.Fill(testValue);

            //Assert
            Assert.AreEqual(expected, testValue.Rows.Count);
        }

        [TestMethod]
        public void GetUserNameTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            string expected = "Jonas Ibrahim";
            string expected2 = "DonF";

            //Act
            string name = core.DataHandler.GetUserName("1234");
            string name2 = core.DataHandler.GetUserName("4242");

            //Assert
            Assert.AreEqual(expected, name);
            Assert.AreEqual(expected2, name2);
        }

        [TestMethod]
        public void InfoToListTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            int expected = 11;

            //Act
            List<Item>  output = core.DataHandler.InfoToList();

            //Assert
            Assert.AreEqual(expected, output.Count);
        }

        [TestMethod]
        public void UserToListTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            int expected = 5;

            //Act
            List<string> output = core.DataHandler.UserToList();

            //Assert
            Assert.AreEqual(expected, output.Count);
        }

        [TestMethod]
        public void OrderToListTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            int expected = 2;

            //Act
            List<Order> output = core.DataHandler.OrderToList();

            //Assert
            Assert.AreEqual(expected, output.Count);
        }


        [TestMethod]
        public void LocationToListTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            int expected = 30;

            //Act
            List<Location> output = core.DataHandler.LocationToList();

            //Assert
            Assert.AreEqual(expected, output.Count);
        }

        [TestMethod]
        public void LogToListTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);

            //Act
            List<LogItem> output = core.DataHandler.LogToList("2011600");

            //Assert
            Assert.IsNotNull(output);
        }

        [TestMethod()]
        public void GetItemFromItemNoTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);

            //Act
            Item output = core.DataHandler.GetItemFromItemNo("2011600");

            //Assert
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void GetDataFromItemNoTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            int expected = 1;

            //Act
            MySqlDataAdapter output = core.DataHandler.GetDataFromItemNo("215250", "information");
            DataTable testValue = new DataTable();
            output.Fill(testValue);

            //Assert
            Assert.AreEqual(expected, testValue.Rows.Count);
        }

        [TestMethod]
        public void GetUsageTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            int expected = 84;

            //Act
            int testValue = core.DataHandler.GetUsage("2011600");

            //Assert
            Assert.AreEqual(expected, testValue);
        }


        [TestMethod]
        public void GetMaxShelfTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            int expected = 6;

            //Act
            int testValue = core.DataHandler.GetMaxShelf();

            //Assert
            Assert.AreEqual(expected, testValue);
        }

        
        [TestMethod]
        public void GetMaxSpaceTest()
        {
            //Arrange
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            int expected = 5;

            //Act
            int testValue = core.DataHandler.GetMaxSpace();

            //Assert
            Assert.AreEqual(expected, testValue);
        }

    }
}
