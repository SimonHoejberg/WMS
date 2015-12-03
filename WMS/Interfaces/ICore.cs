using WMS.Handlers;
using WMS.WH;
using System.Collections.Generic;

namespace WMS.Interfaces
{
    /// <summary>
    /// An interface the a core class must implement 
    /// </summary>
    public interface ICore
    {
        void Run();

        IWindowHandler WindowHandler { get; }

        DataHandler DataHandler { get; }

        List<Item> SortNewItems(List<Item> items, string orderNo, out Dictionary<Item, Location> itemPlaced);

        string GetTimeStamp();

        void changeLang();
        
        string UserName { get; set; }

        ILang Lang { get;}

    }
}
