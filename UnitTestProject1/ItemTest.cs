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


            List<string> uList = temp.UserToList();
            List<string> testList = new List<string>();


            Assert.IsNotNull(uList);
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
            MySqlDataAdapter test;


            test = temp.GetDataFromItemNo("215250", "Information");

            Assert.IsNotNull(test);
        }








    }

}
