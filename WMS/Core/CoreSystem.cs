using System;
using System.Collections.Generic;
using WMS.Interfaces;
using WMS.WH;
using WMS.Handlers;
using WMS.Lang;

namespace WMS.Core
{
    public class CoreSystem : ICore
    {
        //Handlers and the warehouse
        private IWindowHandler windowHandler;
        private DataHandler dataHandler;
        private Warehouse warehouse;
        //Language
        private bool da = true;
        public ILang Lang { get; private set; } = new LangDa();

        public string UserName { get; set; } //The name of the user using the program

        public CoreSystem(IMain main)
        {
            //Creates the differens handlers an the warehouse class
            dataHandler = new DataHandler(this);
            windowHandler = new WindowHandler(this, main);
            warehouse = new Warehouse(this);
        }

        /// <summary>
        /// Runs the main windows an starts the program
        /// </summary>
        public void Run()
        {
            windowHandler.Run();
        }

        public IWindowHandler WindowHandler { get { return windowHandler; } }

        public DataHandler DataHandler { get { return dataHandler; } }

        /// <summary>
        /// Returns the time right now formated
        /// </summary>
        /// <returns></returns>
        public string GetTimeStamp()
        {
            return DateTime.Now.ToString("dd-MM-yy HH:mm:ss");
        }

        /// <summary>
        /// Sorts the new items from rigister in the warehouse
        /// Returns a list with not placed items and as out parameter a list with items placed
        /// </summary>
        /// <param name="items"></param>
        /// <param name="orderNo"></param>
        /// <param name="itemPlaced"></param>
        /// <returns></returns>
        public List<Item> SortNewItems(List<Item> items,string orderNo, out Dictionary<Item,Location> itemPlaced)
        {
            warehouse.CreateWH(orderNo); //Creates the warehouse with the locations from the database
            return warehouse.FindOptimalLocation(items, out itemPlaced);
        }

        /// <summary>
        /// Changes the language in every window
        /// </summary>
        public void changeLang()
        {
            if (da)
            {
                Lang = new LangEn();
                windowHandler.ChangeLang(Lang);
                da = false;
            }
            else
            {
                Lang = new LangDa();
                windowHandler.ChangeLang(Lang);
                da = true;
            }
        }
    }
}