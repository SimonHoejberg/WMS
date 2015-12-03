using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.WH
{
    /// <summary>
    /// A class that holdes a Order No. used only for register in the textbox search fuction 
    /// </summary>
    public class Order
    {
        private int orderNo;
        public Order(int orderNo)
        {
            this.orderNo = orderNo;
        }

        public int OrderNo { get { return orderNo; } }

        public override string ToString()
        {
            return orderNo.ToString();
        }
    }
}
