using System.Collections.Generic;
using WMS.Core;

namespace WMS.FindClass
{
    public class FindItem
    {
        public List<ItemType> ItemList = new List<ItemType>();
        ItemType Item = new ItemType(1564, "adolf", 2, 5, 5);
        ItemType Item2 = new ItemType(1534, "hitler", 21, 6, 55);


        public void LoadItemList()
        {
            // data from DB
            ItemList.Add(Item);
            ItemList.Add(Item2);

        }


        public int FinditemNumber(string name)
        {

            foreach (ItemType number in ItemList)
            {
                if (name.Equals(number.Description))
                {
                    return number.Location;
                }

            }
            return 0;
        }


        public ItemType Find_item(string name)
        {

            foreach (ItemType ite in ItemList)
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
