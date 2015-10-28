using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Core
{
    class ItemType
    {
        private int itemNo;
        private string description;
        private int inStock;
        private int location;
        private int size;

        public ItemType(int itemNo, string description, int inStock, int location, int size)
        {
            this.itemNo = itemNo;
            this.description = description;
            this.inStock = inStock;
            this.location = location;
            this.size = size;

        }

        public int ItemNo{ get { return itemNo; }}

        public string Description { get { return description; }} 

        public int Location {get { return location; }}

        public int InStock { get { return inStock; } }

        public int Size { get { return size; }}
    }
}
