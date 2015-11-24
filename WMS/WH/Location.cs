
namespace WMS.WH
{
    public class Location
    {
        public string Id { get; }
        public int Shelf { get; }
        public int ShelfNo { get; }
        public string ItemNo { get; }
        public int Space { get; }
        public int Quantity { get; }

        public Location(string id, int shelf, int shelfNo, string itemNo, int space, int quantity)
        {
            Id = id;
            Shelf = shelf;
            ShelfNo = shelfNo;
            ItemNo = itemNo;
            Space = space;
            Quantity = quantity;
        }

        public string LocationString => ToString();

        public override string ToString() => $"{Shelf}:{ShelfNo}";


    }
}