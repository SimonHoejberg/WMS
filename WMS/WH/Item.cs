using System;

namespace WMS.WH
{
    public class Item : IComparable
    {
        public string ItemNo { get; }
        public string Description { get; }
        public string Location { get; set; }
        public int Usage { get; } = 0;
        public int InStock { get; }
        public int Size { get; }

        public Item(string itemNo, string description, int inStock, string location, int size, int itemUsage)
        {
            ItemNo = itemNo;
            Description = description;
            InStock = inStock;
            Location = location;
            Size = size;
            Usage = itemUsage;
        }

        public string Identification => $"{ItemNo}: {Description}";

        public override string ToString() => $"{ItemNo}: {Description}: {Size}: {InStock}:";

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
