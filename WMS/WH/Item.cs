using System;

namespace WMS.WH
{
    public class Item : IComparable
    {
        private string itemNo;
        private string description;
        private int inStock;
        private int shelf;
        private int space;
        private int size;

        public Item(string itemNo, string description, int inStock, int shelf, int size)
        {
            this.itemNo = itemNo;
            this.description = description;
            this.inStock = inStock;
            this.shelf = shelf;
            this.size = size;
        }

        public string ItemNo{ get { return itemNo; }}
        public string ItemNoString { get { return Convert.ToString(ItemNo); } }

        public string Description { get { return description; }}

        public int Shelf {get { return shelf; }
                          set { this.shelf = value; } }

        public int Space { get { return space; } }

        public int InStock { get { return inStock; } }

        public int Size { get { return size; }}

        public override string ToString()
        {
            return ItemNo + ":" + Description + ":" + Size + ":" + InStock + ":" + Shelf;
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

        public void ReduceItem(string itemNo, int quantity)
        {

        }
    }
}
