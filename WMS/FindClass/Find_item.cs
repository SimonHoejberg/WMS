using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.FindClass
{
    class Find_Item{
        List<Core.ItemType> ItemList = new List<Core.ItemType>();
        Core.ItemType Item = new Core.ItemType(1564, "adolf", 2, 4 ,5);
        Core.ItemType Item2 = new Core.ItemType(1534, "hitler", 21,56, 55);


        public void LoadItemList()
    {
            // data from DB
            ItemList.Add(Item);
            ItemList.Add(Item2);

        }





        public Core.ItemType Find_item(string name)
    {
            LoadItemList();
        foreach (Core.ItemType ite in ItemList)
        {
            if (name.Equals(ite.Description))
            {
                   
                    return ite; 
            }
        }
        return null;

        //methoder til at finde list over item eller broken item, return list()
    }
}
}
