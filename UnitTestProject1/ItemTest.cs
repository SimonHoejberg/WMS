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

        //Check GetTimeStamp() don`t return null
        [TestMethod]
        public void GetTimeStamp()
        {
            
            IMain main = new Main();
            CoreSystem Test = new CoreSystem(main);
            string temp = "";

            temp = Test.GetTimeStamp();
            
            Assert.IsNotNull(temp);
        }
        

        //Check if GetData() don`t return null
        [TestMethod]
        public void GetData()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            MySqlDataAdapter output;

            output = temp.GetData("Information");

            Assert.IsNotNull(output);
        }

        //Check if GetUserName() returns the rigth name
        [TestMethod]
        public void GetUserName()
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

        //Check if InfoToList() returns a list that`s not null and 11 in size
        [TestMethod]
        public void InfoToList()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<Item> output;
          
            output = temp.InfoToList();

            Assert.AreEqual(output.Count, 11);
            Assert.IsNotNull(output);
        }

        //Check if UserToList() returns a list that`s not null and 5 in size
        [TestMethod]
        public void UserToList()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<string> output;
        
            output = temp.UserToList();

            Assert.IsNotNull(output);
            Assert.AreEqual(output.Count, 5);
        }

        //Check if UserToList() returns a list that`s not null and 2 in size
        [TestMethod]
        public void OrderToList()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<Order> output = new List<Order>();
        
            output = temp.OrderToList();

            Assert.AreEqual(output.Count, 2);
            Assert.IsNotNull(output);
        }



        [TestMethod]
        public void LocationToList()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<Location> output;
        
            output = temp.LocationToList();

            Assert.AreEqual(output.Count, 30);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void LogToListTest()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            string tempString = "2011600";
            List<LogItem> output;

            output = temp.LogToList(tempString);

            Assert.IsNotNull(output);
        }

        [TestMethod()]
        public void GetItemFromItemNo()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            string tempString = "2011600";
            Item output;

            output = temp.GetItemFromItemNo(tempString);

            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void GetDataFromItemNo()
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
        public void GetUsage()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);

            int output = temp.GetUsage("2011600");

            Assert.IsNotNull(output);
            Assert.AreEqual(output, 84);
        }


        [TestMethod]
        public void GetMaxShelf()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);

            int output = temp.GetMaxShelf();

            Assert.AreEqual(output, 6);
            Assert.IsNotNull(output);
        }

        
        [TestMethod]
        public void GetMaxSpace()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            int test = 0;

            test = temp.GetMaxSpace();

            Assert.AreEqual(test, 5);
        }

        //-----------------------------------------------------//   


    }

}
