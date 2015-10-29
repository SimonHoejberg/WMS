using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Core
{
    class Location
    {
        public int shelfUnit;
        public int shelfNumber;
        public int shelfPosition;
        public string itemName;
        public int itemQuantity = 0;
        public int itemNumber = 0;
        
        public Location(string ItemName, int ShelfUnit, int ShelfNumber, int ShelfPosition, int ItemQuantity, int ItemNumber)
        {
            itemName = ItemName;
            shelfUnit = ShelfUnit;
            shelfNumber = ShelfNumber;
            shelfPosition = ShelfPosition;
            itemQuantity = ItemQuantity;
            itemNumber = ItemNumber;
        }


    }
}
