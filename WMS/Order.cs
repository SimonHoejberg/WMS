﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS
{
    public class Order
    {
        private int orderNo;
        public Order(int orderNo)
        {
            this.orderNo = orderNo;
        }

        public int OrderNo { get { return orderNo; } }
    }
}
