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
        private IWindowHandler windowHandler;
        private DataHandler dataHandler;
        private Warehouse wh;
        private bool da = true;
        public string User { get; set; }
        public ILang Lang { get; private set; } = new LangDa();
        public string UserName { get; private set; }

        public CoreSystem(IMain main)
        {
            dataHandler = new DataHandler(this);
            windowHandler = new WindowHandler(this, main);
            wh = new Warehouse(this);
        }

        public void Run()
        {
            windowHandler.Run();
            UserName = dataHandler.GetUserName(User);
        }

        public IWindowHandler WindowHandler { get { return windowHandler; } }

        public DataHandler DataHandler { get { return dataHandler; } }

        public string GetTimeStamp()
        {
            return DateTime.Now.ToString("dd-MM-yy HH:mm:ss");
        }

        public void SortNewItems(List<Item> items,string orderNo)
        {
            wh.CreateWH(orderNo);
            wh.FindOptimalLocation(items);
        }

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