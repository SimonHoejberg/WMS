using System;
using System.Collections.Generic;
using WMS.Reference;

namespace WMS.WH
{
    public class Warehouse
    {
        List<Item> ItemNotPlaced = new List<Item>();

        public List<Item> ItemList = new List<Item>();
        Item Item = new Item(1564, "adolf", 2, 5, 5);
        Item Item2 = new Item(1534, "hitler", 21, 6, 55);

        private List<Item> algorithm(List<Item> Product)
        {
            add();
            int i = 0;
            bool j = true;
            int r = 0;
            bool f;
            Product.Sort();
            while (j && i<2)
            {
            /*    if (Product[i].Description == null)
                {
                    j = false;
                }*/
                r = FindShelfNumber(Product[i]);
                f = FindAvaliableSpace(Product[i],Space, r);
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
        

        public int FindShelfNumber(Item Product)
        {    
            var shelfID = FinditemNumber(Product.Description);
            return shelfID;
        }

        /*
        //Reduced: find_item to reduce and update
        public bool reduceItem(item)
        {
                    = FindItem()
               }
        //Waste: find item and remove from system
*/
        public bool FindAvaliableSpace(Item Product, List<Location> x, int i)
        {
            if (Product.Size <= EmptySpace(x[i], WarehouseLayout.shelfsize, i))
            {
                PlaceItem(Product, x[i]);
                Console.WriteLine("Yes");
                return true;
            }
            else if (Product.Size > EmptySpace(x[i], WarehouseLayout.shelfsize, i))
            {
                Console.WriteLine("ok");
                return FindAvaliableSpace(Product, x, i++);
            }
            else if (WarehouseLayout.racks > 6)
            {
                Console.WriteLine("whyyyyyy");
                return false;
            }
            Console.WriteLine("no");
            return false;
        }

        public List<Location> Space = new List<Location>();

        Location locale = new Location(0, "mike1", 2, 5, 9, 100, 1564);
        Location locale1 = new Location(0, "mike", 2, 5, 9, 100, 1564);
        Location locale2 = new Location(0, "mike2", 2, 5, 9, 100, 1564);
        Location locale3 = new Location(0, "mike3", 2, 5, 9, 100, 1564);
        Location locale4 = new Location(0, "mike4", 2, 6, 9, 100, 1564);
        Location locale5 = new Location(0, "mike5", 2, 6, 9, 100, 1564);
        Location locale6 = new Location(0, "mike6", 2, 6, 9, 100, 1564);

        public void add()
        {
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
            foreach (Location space in Space)
            {
                if (ShelfID.shelfNumber == space.shelfNumber)
                {
                    x = x + space.itemQuantity;
                }
            }
            return x;

        }

        public bool PlaceItem(Item Product, Location ShelfID)
        {
            if (Product != null)
            {
                var NewPlace = new Location(0, Product.Description, ShelfID.shelfUnit, ShelfID.shelfNumber, ShelfID.shelfPosition + Product.Size, ShelfID.itemQuantity, Product.ItemNo);
                return true;
            }
            else
            {
                return false;
            }


        }



        /*    List<location> LocationList = new List<location>();


                public int EmptySpace(int shelfID)
                {
                    location
                }

      */


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

 /*List<location> LocationList = new List<location>();



        public int Find_Place(string name)
        {
            foreach (location in LocationList)
            {
                if (name.Equals(locationList.name))
                {
                    return Location;
                }
            }

        }*/


}
