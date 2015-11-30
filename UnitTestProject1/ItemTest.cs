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
       public void TestMethod1()
        { 
            //??????????????
            //Arrange
            int a = 0;
            Item anItem = new Item("1000", "An Item", 9, "2.3", 10);

            //Act
            a = anItem.CompareTo(new Item("1000", "An Item", 9, "2.3", 10));

            //Assert
            Assert.AreEqual(1, 1);
        }
        [TestMethod]
        public void TestMethod2()
        {
            
            IMain main = new Main();
            string temp = "";
            CoreSystem Test = new CoreSystem(main);


            temp = Test.GetTimeStamp();

            Assert.IsNotNull(temp);
        }

        [TestMethod]
        public void TestMethod3()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            //More name
            string name = "";

            name = temp.GetUserName("1234");

            Assert.AreEqual("Jonas Ibrahim", name);
        }

        [TestMethod]
        public void TestMethod4()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);


            List<string> output;
            List<string> test = new List<string>();

            output = temp.UserToList();

            CollectionAssert.ReferenceEquals(test, output);
            Assert.IsNotNull(output);
           // test for equals list<string>


        }
        [TestMethod]
        public void TestMethod5()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            int test = 0;

            test = temp.GetMaxSpace();

            Assert.AreEqual(test, 5);
        }

        [TestMethod]
        public void TestMethod6()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            MySqlDataAdapter output;
            MySqlDataAdapter test = new MySqlDataAdapter();


            output = temp.GetDataFromItemNo("215250", "Information");

            Assert.ReferenceEquals(test, output);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void TestMethod7()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            MySqlDataAdapter output;
            MySqlDataAdapter test = new MySqlDataAdapter();


            output = temp.GetData("Information");
            Assert.ReferenceEquals(test, output);
           Assert.IsNotNull(output);
        }

        [TestMethod]
        public void TestMethod8()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<Location> output;
            List<Location> test = new List<Location>();


            output = temp.LocationToList();

            CollectionAssert.ReferenceEquals(test, output);
            Assert.IsNotNull(output);
        }


        [TestMethod]
        public void TestMethod9()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<Order> output = new List<Order>();
            List<Order> test = new List<Order>();



            output = temp.OrderToList();



            CollectionAssert.Equals(output, test);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void TestMethod10()
        {
            IMain main = new Main();
            ICore core = new CoreSystem(main);
            DataHandler temp = new DataHandler(core);
            List<Item> output;
            List<Item> test = new List<Item>();


            output = temp.InfoToList();

            CollectionAssert.ReferenceEquals(test, output);
            Assert.IsNotNull(output);
        }





    }

}
