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

        Core.Location locale = new Core.Location(8, "mike1", 2, 5 , 9, 100, 1564);
        Core.Location locale1 = new Core.Location(8, "mike", 2, 5, 9, 100, 1564);
        Core.Location locale2 = new Core.Location(8, "mike2", 2, 5, 9, 100, 1564);
        Core.Location locale3 = new Core.Location(8, "mike3", 2, 5, 9, 100, 1564);
        Core.Location locale4 = new Core.Location(1, "mike4", 2, 6, 9, 100, 1564);
        Core.Location locale5 = new Core.Location(1, "mike5", 2, 6, 9, 100, 1564);
        Core.Location locale6 = new Core.Location(1, "mike6", 2, 6, 9, 100, 1564);

        public void add() {
            Space.Add(locale);
            Space.Add(locale1);
            Space.Add(locale2);
            Space.Add(locale3);
            Space.Add(locale4);
            Space.Add(locale5);
            Space.Add(locale6);

        }




        public int EmptySpace(Core.Location ShelfID, int Max, int i)
        {
            int x = 0;
            foreach(Core.Location space in Space)
            {
                if(ShelfID.shelfNumber == space.shelfNumber)
                {
                    x = x + space.productSize;
                    Console.WriteLine(x);
                }
            }
            return x;

        }

        public bool PlaceItem(Core.ItemType Product, Core.Location ShelfID)
        {
            if (Product != null)
            {
                var NewPlace = new Core.Location(Product.Size, Product.Description, ShelfID.shelfUnit, ShelfID.shelfNumber, ShelfID.shelfPosition + Product.Size, ShelfID.itemQuantity, Product.ItemNo);
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

