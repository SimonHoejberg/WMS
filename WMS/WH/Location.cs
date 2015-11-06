
namespace WMS.WH
{
    public class Location
    {
        string unit;
        int shelf;
        int shelfNo;
        string itemNo;
        int space;
        int quantity;

        public string Unit { get { return unit; }}
        public int Shelf { get { return shelf; } }
        public int ShelfNo { get { return shelfNo; } }
        public string ItemNo { get { return itemNo; } }
        public int Space { get { return space; } }
        public int Quantity { get { return quantity; } }

        public Location(string unit, int shelf, int shelfNo, string itemNo, int space, int quantity)
        {
            this.unit = unit;
            this.shelf = shelf;
            this.shelfNo = shelfNo;
            this.itemNo = itemNo;
            this.space = space;
            this.quantity = quantity;
        }

        public override string ToString()
        {
            return unit + ":" + shelf + ":" + shelfNo + ":" + itemNo + ":" + space + ":" + quantity;
        }


    }
}