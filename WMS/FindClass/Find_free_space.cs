using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.FindClass
{
    class FindFreeSpace
    {
        public List<Core.Location> Space = new List<Core.Location>();

        public int FinditemNumber(string name)
        {
            int i = 0;
            foreach(Core.Location number in Space)
            {
                if (name.Equals(number.itemName))
                {
                    return i;
                }
                i++;
            }
            return 0;
        }

        public int EmptySpace(Core.Location ShelfID, int Max, int i)
        {
            int x = 0;
            foreach(Core.Location space in Space)
            {
                if(ShelfID.shelfNumber == space.shelfNumber)
                {
                    x = x + space.itemQuantity;
                }
            }
            return x;

        }

        public bool PlaceItem(Core.ItemType Product, Core.Location ShelfID)
        {
            if (Product != null)
            {
                var NewPlace = new Core.Location(Product.Description, ShelfID.shelfUnit, ShelfID.shelfNumber, ShelfID.shelfPosition + Product.Size, ShelfID.itemQuantity, Product.ItemNo);
                return true;
            }
            else
            {
                return false;
            }

           
        }



        /*    List<location> LocationList = new List<location>();
            class Find_free_space
            {


                public int EmptySpace(int shelfID)
                {
                    location
                }

                }*/
    }
    }

