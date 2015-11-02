
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
        
        public Location(int ProductSize, string ItemName, int ShelfUnit, int ShelfNumber, int ShelfPosition, int ItemQuantity, int ItemNumber)
        {
            productSize = ProductSize;
            itemName = ItemName;
            shelfUnit = ShelfUnit;
            shelfNumber = ShelfNumber;
            shelfPosition = ShelfPosition;
            itemQuantity = ItemQuantity;
            itemNumber = ItemNumber;
        }


    }
}
