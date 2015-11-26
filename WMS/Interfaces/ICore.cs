using WMS.Handlers;
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
        
        string UserName { get; set; }

        ILang Lang { get;}

    }
}
