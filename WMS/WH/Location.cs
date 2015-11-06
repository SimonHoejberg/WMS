
namespace WMS.WH
{
    public class Location
    {
        string unit;
        string shelf;
        string shelfNo;
        string itemNo;
        string space;
        string quantity;

        public Location(string unit, string shelf, string shelfNo, string itemNo, string space, string quantity)
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
            return "  " + itemNo;
        }


    }
}