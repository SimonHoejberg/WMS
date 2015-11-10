using System;

namespace WMS.WH
{
    public class Item : IComparable
    {
        private string itemNo;
        private string description;
        private int inStock;
        private string location;
        private int itemUsage;
        private int size;

        public Item(string itemNo, string description, int inStock, string location, int size, int itemUsage)
        {
            this.itemNo = itemNo;
            this.description = description;
            this.inStock = inStock;
            this.location = location;
            this.size = size;
            this.itemUsage = itemUsage;
        }

        public string ItemNo{ get { return itemNo; }}

        public string Description { get { return description; }}

        public string Location { get { return location; } set { location = value; } }

        public int Usage { get { return itemUsage; } }

        public int InStock { get { return inStock; } }

        public int Size { get { return size; }}

        public override string ToString()
        {
            return ItemNo + " :" + Description + ":" + Size + ":" + InStock + ":";// Shelf;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Item otherItem = obj as Item;
            if (obj != null)
                return otherItem.inStock.CompareTo(this.inStock);
            else
                throw new ArgumentException("Object is not an Item");
        }
    }
}
