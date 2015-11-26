﻿using WMS.Handlers;
using WMS.WH;
using System.Collections.Generic;

namespace WMS.Interfaces
{
    public interface ICore
    {
        void Run();

        IWindowHandler WindowHandler { get; }

        DataHandler DataHandler { get; }

        void SortNewItems(List<Item> items, string orderNo);

        string GetTimeStamp();

        void changeLang();

        string User { get; set; }
        
        string UserName { get;}

        ILang Lang { get;}

    }
}
