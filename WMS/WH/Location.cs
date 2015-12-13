
namespace WMS.WH
{
    /// <summary>
    /// A class that can be made object of that holds the different values from the specific location from the database
    /// </summary>
    public class Location
    {
        public string Id { get; }
        public string Shelf { get; }
        public string Space { get; }
        public string ItemNo { get; set; }
        public int Quantity { get; set; }
        public int BestLocation { get; }
        public int Usage { get; set; }

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

        public string LocationAndQuantity => $"{ToString()} : {Quantity}";

        public string LocationString => ToString(); //For use in dataGridComboBoxView, it can not use ToString(), it needs a property;

        public override string ToString() => $"{Shelf}.{Space}"; //The way that the location is displayed for reading by the user


    }
}