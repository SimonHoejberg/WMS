using System;

namespace WMS.Core
{
    public class ItemType : IComparable
    {
        private int itemNo;
        private string description;
        private int inStock;
        private int location;
        private int size;

        public ItemType(int itemNo, string description, int inStock, int location, int size)
        {
            this.itemNo = itemNo;
            this.description = description;
            this.inStock = inStock;
            this.location = location;
            this.size = size;

        }

        public int ItemNo{ get { return itemNo; }}

        public string Description { get { return description; }} 

        public int Location {get { return location; }}

        public int InStock { get { return inStock; } }

        public int Size { get { return size; }}

        public override string ToString()
        {
            return "Item: " + ItemNo + "  Description: " + Description;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            ItemType otherItem = obj as ItemType;
            if (obj != null)
                return otherItem.inStock.CompareTo(this.inStock);
            else
                throw new ArgumentException("Object is not a Item");
        }
    }
}
