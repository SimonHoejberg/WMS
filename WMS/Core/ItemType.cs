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
        public List<List<int>> location;
        public int totalQuantity;
        public int usage;
        public int quantityToFull;

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

        public List<List<int>> Location
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
                    tempTotalQuantity += location[i][3];
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

        public ItemType(int itemnumber, string itemname, int itemusage, int itemquantityToFull)
        {
            itemNumber = itemnumber;
            name = itemname;
            usage = itemusage;
            quantityToFull = itemquantityToFull;

        }

    }
}
