using System;

namespace WMS.WH
{
    /// <summary>
    /// A class that can be made object of that holds the different values from the specific item from the database
    /// </summary>
    public class Item : IComparable
    {
        public string ItemNo { get; }
        public string Description { get; }
        public string Location { get; set; }
        public int Usage { get; } = 0;
        public int InStock { get; }

        public Item(string itemNo, string description, int inStock, string location, int itemUsage)
        {
            ItemNo = itemNo;
            Description = description;
            InStock = inStock;
            Location = location;
            Usage = itemUsage;
        }

        public string Identification => $"{ItemNo}: {Description}"; //Returns the two strings identifing the item

        public override string ToString() => $"{ItemNo}: {Description}: {InStock}:";

        //Compare fuction used in warehouse to sort the item by its usage in descending order
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Item otherItem = obj as Item;
            if (obj != null)
                return otherItem.Usage.CompareTo(Usage);
            else
                throw new ArgumentException("Object is not an Item");
        }
    }
}
