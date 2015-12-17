using WMS.Interfaces;
using System.Collections.Generic;

namespace WMS.WH
{
    public class Warehouse
    {
        private ICore core;
        private Location[,] locations; //A two dimensional array that holds every location with a item from the database 
        private Dictionary<string, int> quickPlace; //A dictionary used to help the algorithm to fast place
        private List<Item> itemsNotPlaced; //A list which contains the items not placed in the algorithm
        private Dictionary<Item, Location> itemsPlaced; //A dictionary which contains the item and locations placed in the algorithm
        private int maxShelf = 0, maxSpace = 0; //Values used to create the location array and stop the algorithm if there is no more space
        private string orderNo; //The order no which the items is from

        public Warehouse(ICore core)
        {
            this.core = core;
        }

        /// <summary>
        /// Creates a virtuel representation of the items on the locations in the warehouse
        /// </summary>
        /// <param name="orderNo"></param>
        public void CreateWarehouse(string orderNo)
        {
            this.orderNo = orderNo; //Sets the order no
            quickPlace = new Dictionary<string, int>(); //Makes a new quickPlace dictionary so it is empty and ready
            locations = new Location[MaxShelf(), MaxSpace()]; //A two dimensional array which has room for every location in the database
            List<Location> locationList = core.DataHandler.LocationToList(); //Gets the locations from the database
            foreach (Location location in locationList)
            {
                int space = (int.Parse(location.Space) - 1); //Gets the space for a location in array number
                locations[location.BestLocation, space] = location; //The best location number tells which shelf should be filled first
                //If the is no quantity on a location there is no items on that location
                if (location.Quantity <= 0)
                {
                    locations[location.BestLocation, space].ItemNo = "0";
                }
                //If an item exist on a location add its latest bestLocation to the quickPlace dictonary
                if (!location.ItemNo.Equals("0"))
                {
                    if (!quickPlace.ContainsKey(location.ItemNo))
                    {
                        quickPlace.Add(location.ItemNo, location.BestLocation);
                    }
                    else
                    {
                        quickPlace.Remove(location.ItemNo);
                        quickPlace.Add(location.ItemNo, location.BestLocation);
                    }
                }
            }
        }

        /// <summary>
        /// Places an item on a location both in the virtuel warehouse and on the database 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="item"></param>
        private void PlaceItem(Location location, Item item)
        {
            //Places the item on the location on the database
            core.DataHandler.PlaceItem(location.Id, location.LocationString, item.InStock.ToString(), item.ItemNo, item.Usage.ToString(), orderNo, item.Description);
            //Fills in the location on the virtuel warehouse  
            location.ItemNo = item.ItemNo;
            location.Quantity = item.InStock;
            location.Usage = item.Usage;
            itemsPlaced.Add(item, location); //Adds the item and location to the return list of placed items
        }

        /// <summary>
        /// Finds the avaliable space for the item an places it or it no space adds it to the not placed list
        /// </summary>
        /// <param name="item"></param>
        /// <param name="shelf"></param>
        /// <param name="space"></param>
        private void FindAvaliableSpace(Item item, int shelf, int space)
        {
            /* 
                If there is no items on the location
                or the item on the location is the same item as the new item
                it then places the item
            */
            if (LocationEmpty(shelf, space) || (ItemOnLocationSameAsNewItem(shelf, space, item)))
            {
                PlaceItem(locations[shelf, space], item);
                return; //Stops the algorithm
            }
            else
            {
                //Increments either the space or shelf based on if it the last space in a shelf
                if (space < (maxSpace - 1))
                {
                    space++;
                }
                else if (shelf < (maxShelf - 1))
                {
                    space = 0;
                    shelf++;
                }
                else
                {
                    //If there is no more shelfs and no more space on the shelf it adds it to the not placed return list
                    itemsNotPlaced.Add(item);
                    return; //Stops the algorithm
                }
                FindAvaliableSpace(item, shelf, space); //Recursive call
            }
        }

        /// <summary>
        /// Finds and places new items registered in the warehouse and returns two list a not placed list by return and a placed list by out
        /// </summary>
        /// <param name="items"></param>
        /// <param name="itemsPlaced"></param>
        /// <returns></returns>
        public List<Item> FindOptimalLocationForNewItems(List<Item> items, out Dictionary<Item, Location> itemsPlaced)
        {
            this.itemsPlaced = new Dictionary<Item, Location>(); //Creates a new items placed list
            itemsNotPlaced = new List<Item>(); //Creates a new items placed list
            items.Sort(); //Sorts the items by their compare fuction
            foreach (Item item in items)
            {
                int shelf = 0, space = 0; //Values used for the start of the recursive method
                //If a item has a quickPlace value it gets it and used that as a shelf
                if (quickPlace.ContainsKey(item.ItemNo))
                {
                    quickPlace.TryGetValue(item.ItemNo, out shelf);
                }
                FindAvaliableSpace(item, shelf, space); //Calls the recursive method
            }
            itemsPlaced = this.itemsPlaced; //Assigns the item placed list to the out parameter
            return itemsNotPlaced; //Returns the not placed list
        }

        #region Helper Methods
        /// <summary>
        /// Gets the max count of spaces on a row on a shelf
        /// </summary>
        /// <returns></returns>
        private int MaxSpace()
        {
            maxSpace = core.DataHandler.GetMaxSpace();
            return maxSpace;
        }

        /// <summary>
        /// Gets the max count of rows
        /// </summary>
        /// <returns></returns>
        private int MaxShelf()
        {
            maxShelf = core.DataHandler.GetMaxShelf();
            return maxShelf;
        }

        /// <summary>
        /// Checks if the location is empty
        /// </summary>
        /// <param name="shelf"></param>
        /// <param name="space"></param>
        /// <returns></returns>
        private bool LocationEmpty(int shelf, int space)
        {
            Location location = locations[shelf, space]; //Gets the location
            return location.ItemNo.Equals("0");
        }

        /// <summary>
        /// Checks if the item is the same on the location as the new item
        /// </summary>
        /// <param name="shelf"></param>
        /// <param name="space"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ItemOnLocationSameAsNewItem(int shelf, int space, Item item)
        {
            Location location = locations[shelf, space]; //Gets the location
            return (location.ItemNo.Equals(item.ItemNo) && (location.Quantity + item.InStock) <= 250); //Returns true if it the same item and it has room for more items
        }
        #endregion

    }
}
