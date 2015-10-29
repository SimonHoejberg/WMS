using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Warehouse
{
    class Warehouse
    {

        //Registering:trukket alle informationer ind i registrering for at bruge algorithm og få lister tilbage
        public List<Core.ItemType> algorithm(List<Core.ItemType> Product)
        {
            List<Core.ItemType> ItemNotPlaced = new List<Core.ItemType>();
            int i = 0;
            bool j = true;
            int x = 0;
            bool f;
            Product.Sort();
            while (j)
            {
                if (Product[i].Description == null)
                {
                    j = false;
                }

                x = FindShelfNumber(Product[i]);
                f = FindAvaliableSpace(Product[i], x);
                if (f == false)
                {
                    ItemNotPlaced.Add(Product[i]);
                }
                i++;
            }
            return ItemNotPlaced;
        }
        //gui classer sender information
        //Move: find item til at flytte,find itemplacering, find alle freespace, og derefter tildel ny placering
        public List<T> moveItem(item.size)
        {

        }


        public int FindShelfNumber()
        {

        }


        //Reduced: find_item to reduce and update
        public bool reduceItem(item)
        {
                    = FindItem()
               }
        //Waste: find item and remove from system

        public bool FindAvaliableSpace(Core.ItemType Product, int x)
        {
            if (Product.Size <= Findfreespace.EmptySpace(x))
            {
                placeitem(Product[i], x);
                return true;
            }
            else if (Product[i].size > Findfreespace.EmptySpace(x))
            {
                return FindSpace(Product[i], x + 1);
            }
            else
                (x > max_size)
                   {
                return false;
            }
        }

        public void placeItem()*/
    }
}
