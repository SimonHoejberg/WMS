
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

        //Added by Jonas for testing purposes
        Item itemOnLocation;
        public Item LocItem { get { return itemOnLocation; } }
        string LocationString;
        public string LocationToString { get { return LocationString; } }
        //

        public string Unit { get { return unit; }}
        public int Shelf { get { return shelf; } }
        public int ShelfNo { get { return shelfNo; } }
        public string ItemNo { get { return itemNo; } }
        public int Space { get { return space; } }
        public int Quantity { get { return quantity; } }

        public Location(string unit, int shelf, int shelfNo, string itemNo, int space, int quantity)
        {
            //Added by Jonas for testing purposes
            this.itemOnLocation = new Item("7003808", "Dyse", 10, 11, 12);
            this.LocationString = Unit + " " + shelf.ToString() + " " + shelfNo.ToString();
            //
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