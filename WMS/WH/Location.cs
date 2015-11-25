
namespace WMS.WH
{
    public class Location
    {
        public string Id { get; }
        public string Shelf { get; }
        public string Space { get; }
        public string ItemNo { get; set; }
        public int Quantity { get; set; }
        public int BestLocation { get; }
        public int Usage { get; }

        public Location(string id, string shelf, string space, string itemNo, int quantity, int bestLocation, int usage)
        {
            Id = id;
            Shelf = shelf;
            Space = space;
            ItemNo = itemNo;
            Quantity = quantity;
            BestLocation = bestLocation;
            Usage = usage;
        }

        public string LocationString => ToString();

        public override string ToString() => $"{Shelf}:{Space}";


    }
}