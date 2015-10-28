using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Core
{
    class ItemType
    {
        public int itemNumber;
        public string name;
        public List<Location> location;
        public int totalQuantity;
        public int usage;
        public int quantityToFull;

        public ItemType(int ItemNumber, string ItemName, int ItemUsage, int ItemQuantityToFull)
        {
            itemNumber = ItemNumber;
            name = ItemName;
            usage = ItemUsage;
            quantityToFull = ItemQuantityToFull;

        }

        public int ItemNumber
        {    
           get { return itemNumber; }
           set { itemNumber = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        } 

        public List<Location> Location
        {
            get { return location; }
            set
            {
                location = value;
            }
        }

        public int TotalQuantity
        {
            get
            {
                int tempTotalQuantity = 0;

                for (int i = 0; i < location.Count; i++)
                {
                    tempTotalQuantity += location[i].itemQuantity;
                }

                return tempTotalQuantity;
            }
        }

        public int Usage
        {
            get { return usage; }
            set { usage = value; }
        }

        public int QuantityToFull
        {
            get { return quantityToFull; }
            set { quantityToFull = value; }
        }
    }
}
