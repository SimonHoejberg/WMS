
namespace WMS.WH
{
    public class Location
    {
        public int shelfUnit;
        public int shelfNumber;
        public int shelfPosition;
        public string itemName;
        public int itemQuantity = 0;
        public int itemNumber = 0;
        
        public Location(string itemName, int shelfUnit, int shelfNumber, int shelfPosition, int itemQuantity, int itemNumber)
        {
            this.itemName = itemName;
            this.shelfUnit = shelfUnit;
            this.shelfNumber = shelfNumber;
            this.shelfPosition = shelfPosition;
            this.itemQuantity = itemQuantity;
            this.itemNumber = itemNumber;
        }


    }
}
