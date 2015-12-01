using System;
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

namespace UnitTestProject1
{
    [TestClass]
    public class ItemTest
    {
       
        [TestMethod]
        public void TestMethodTimeStamp()
        {
            
            IMain main = new Main();
            CoreSystem Test = new CoreSystem(main);
            string temp = "";

            temp = Test.GetTimeStamp();
            
            Assert.IsNotNull(temp);
        }


        [TestMethod]
        public void TestMethodGetUser()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            string name = "";
            string name2 = "";

            name = temp.GetUserName("1234");
            name2 = temp.GetUserName("4242");

            Assert.AreEqual("Jonas Ibrahim", name);
            Assert.AreEqual("DonF", name2);
        }


        [TestMethod]
        public void TestMethodUserToList()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<string> output;
            List<string> test = new List<string>();

            output = temp.UserToList();

            Assert.IsNotNull(output);
            Assert.AreEqual(output.Count, 5);
        }



        [TestMethod]
        public void TestMethodMaxSpace()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            int test = 0;

            test = temp.GetMaxSpace();

            Assert.AreEqual(test, 5);
        }



        [TestMethod]
        public void TestMethodGetDataFromItemNo()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            MySqlDataAdapter output;
            MySqlDataAdapter test = new MySqlDataAdapter();

            output = temp.GetDataFromItemNo("215250", "Information");

            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void TestMethodGetData()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            MySqlDataAdapter output;
            MySqlDataAdapter test = new MySqlDataAdapter();

            output = temp.GetData("Information");

            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void TestMethodLocationToList()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<Location> output;
            List<Order> test = new List<Order>();

            output = temp.LocationToList();

            Assert.AreEqual(output.Count, 30);
            Assert.IsNotNull(output);
        }


        [TestMethod]
        public void TestMethodOrderToList()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<Order> output = new List<Order>();
            List<Order> test = new List<Order>();

            output = temp.OrderToList();

            Assert.AreEqual(output.Count, 3);
            Assert.IsNotNull(output);
        }



        [TestMethod]
        public void TestMethodInfoToList()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<Item> output;
            List<Item> test = new List<Item>();


            output = temp.InfoToList();

            Assert.AreEqual(output.Count, 11);
            Assert.IsNotNull(output);
        }

    }

}
