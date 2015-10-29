using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.FindClass
{
    class Find_Item{
        public List<Core.ItemType> ItemList = new List<Core.ItemType>();
        Core.ItemType Item = new Core.ItemType(1564, "adolf", 2, 5 ,5);
        Core.ItemType Item2 = new Core.ItemType(1534, "hitler", 21,6, 55);


        public void LoadItemList()
    {
            // data from DB
            ItemList.Add(Item);
            ItemList.Add(Item2);

        }


        public int FinditemNumber(string name)
        {
            
            foreach (Core.ItemType number in ItemList)
            {
                if (name.Equals(number.Description))
                {
                    return number.Location;
                }
                
            }
            return 0;
        }


        public Core.ItemType Find_item(string name)
    {

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
