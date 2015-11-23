
namespace WMS.WH
{
    public class Location
    {
        public string Id { get; }
        public string Unit { get; }
        public int Shelf { get; }
        public int ShelfNo { get; }
        public string ItemNo { get; }
        public int Space { get; }
        public int Quantity { get; }

        public Location(string id, string unit, int shelf, int shelfNo, string itemNo, int space, int quantity)
        {
            Id = id;
            Unit = unit;
            Shelf = shelf;
            ShelfNo = shelfNo;
            ItemNo = itemNo;
            Space = space;
            Quantity = quantity;
        }

        public string LocationString => ToString();

        public override string ToString() => $"{Unit}:{Shelf}:{ShelfNo}";


    }
}