using System.Collections.Generic;
using WMS.Core;

namespace WMS.FindClass
{
    public class FindFreeSpace
    {
        
        public List<Location> Space = new List<Location>();

        Location locale = new Location("mike1", 2, 5 , 9, 100, 1564);
        Location locale1 = new Location("mike", 2, 5, 9, 100, 1564);
        Location locale2 = new Location("mike2", 2, 5, 9, 100, 1564);
        Location locale3 = new Location("mike3", 2, 5, 9, 100, 1564);
        Location locale4 = new Location("mike4", 2, 6, 9, 100, 1564);
        Location locale5 = new Location("mike5", 2, 6, 9, 100, 1564);
        Location locale6 = new Location("mike6", 2, 6, 9, 100, 1564);

        public void add() {
            Space.Add(locale);
            Space.Add(locale1);
            Space.Add(locale2);
            Space.Add(locale3);
            Space.Add(locale4);
            Space.Add(locale5);
            Space.Add(locale6);

        }




        public int EmptySpace(Location ShelfID, int Max, int i)
        {
            int x = 0;
            foreach(Location space in Space)
            {
                if(ShelfID.shelfNumber == space.shelfNumber)
                {
                    x = x + space.itemQuantity;
                }
            }
            return x;

        }

        public bool PlaceItem(Core.ItemType Product, Location ShelfID)
        {
            if (Product != null)
            {
                var NewPlace = new Location(Product.Description, ShelfID.shelfUnit, ShelfID.shelfNumber, ShelfID.shelfPosition + Product.Size, ShelfID.itemQuantity, Product.ItemNo);
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

