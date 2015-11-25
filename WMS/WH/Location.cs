
namespace WMS.WH
{
    public class Location
    {
        public string Id { get; }
        public string Shelf { get; }
        public string Space { get; }
        public string ItemNo { get; }
        public int Quantity { get; }
        public int BestLocation { get; }

        public Location(string id, string shelf, string space, string itemNo, int quantity, int bestLocation)
        {
            Id = id;
            Shelf = shelf;
            Space = space;
            ItemNo = itemNo;
            Quantity = quantity;
            BestLocation = bestLocation;
        }

        public string LocationString => ToString();

        public override string ToString() => $"{Shelf}:{Space}";


    }
}