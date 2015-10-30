using System.Collections.Generic;
using WMS.WH;

namespace WMS.Helper
{
    public class FindItem
    {
        public List<Item> ItemList = new List<Item>();
        Item Item = new Item(1564, "adolf", 2, 5, 5);
        Item Item2 = new Item(1534, "hitler", 21, 6, 55);


        public void LoadItemList()
        {
            // data from DB
            ItemList.Add(Item);
            ItemList.Add(Item2);

        }


        public int FinditemNumber(string name)
        {

            foreach (Item number in ItemList)
            {
                if (name.Equals(number.Description))
                {
                    //return number.Location;
                }

            }
            return 0;
        }


        public Item Find_item(string name)
        {

            foreach (Item ite in ItemList)
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
