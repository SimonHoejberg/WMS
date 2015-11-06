
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
        public int productSize;

        public Location(int productSize, string itemName, int shelfNumber, int itemNumber)
        {
            this.productSize = productSize;
            this.itemName = itemName;
          //  this.shelfUnit = shelfUnit;
            this.shelfNumber = shelfNumber;
          //  this.shelfPosition = shelfPosition;
           // this.itemQuantity = itemQuantity;
            this.itemNumber = itemNumber;
        }

        public override string ToString()
        {
            return "  " + productSize;
        }


    }
}