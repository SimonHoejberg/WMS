
namespace WMS.WH
{
    public class Location
    {
        public string Id { get; }
        public string Shelf { get; }
        public string Space { get; }
        public string ItemNo { get; }
        public int Quantity { get; }

        public Location(string id, string shelf, string space, string itemNo, int quantity)
        {
            Id = id;
            Shelf = shelf;
            Space = space;
            ItemNo = itemNo;
            Quantity = quantity;
        }

        public string LocationString => ToString();

        public override string ToString() => $"{Shelf}:{Space}";


    }
}