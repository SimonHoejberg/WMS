using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.WH
{
    public class LogItem
    {
        private string itemNo;
        private string name;
        private string date;
        private string operation;
        private string amount;
        private string user;

        public LogItem(string itemNo, string name, string date, string operation, string amount, string user)
        {
            this.itemNo = itemNo;
            this.name = name;
            this.date = date;
            this.operation = operation;
            this.amount = amount;
            this.user = user;
        }

        public override string ToString()
        {
            return date + " " + operation + " " + amount + " " + user;
        }

    }
}
