using System;
using System.IO;
using System.Linq;
using WMS.Handlers;
using WMS.Interfaces;
using System.Collections.Generic;
using WMS.Reference;

namespace WMS.WH
{
    /*Place item, find available space, Algoritmen (kører de to andre)*/
    public class Warehouse2
    {
        private ICore core;
        List<Location> locationList;

        int[,] shelfSpace;
        List<int[,]> shelfUnit;

        List<Item> itemList;

        public Warehouse2(ICore core)
        {
            this.core = core;

            this.shelfUnit = new List<int[,]>();
            this.locationList = new List<Location>();
            this.itemList = new List<Item>();
            itemList = GetItems();
            locationList = GetLocations();


        }

        public List<Item> GetItems()
        {
            List<Item> returnList = new List<Item>();
            List<object> temp = core.DataHandler.DataToList(WindowTypes.INFO, null);
            returnList = temp.Cast<Item>().ToList();
            return returnList;
        }

        public List<Location> GetLocations()
        {
            List<Location> returnList = new List<Location>();
            List<object> temp = core.DataHandler.DataToList("location", null);
            returnList = temp.Cast<Location>().ToList();
            return returnList;
        }

        public void SaveWarehouseData()
        {
            //Use datahandler to save itemList/locationList changes to database.
        }

        public bool AddShelfUnit(int newShelfID, int newSize)
        {
            //Add shelfUnit to database
            return true;
        }



    }


}
