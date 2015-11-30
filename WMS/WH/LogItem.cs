using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.WH
{
    public class LogItem
    {

        public string ItemNo { get; }
        public string Name { get; }
        public string Date { get; }
        public string Operation { get; }
        public string Amount { get; }
        public string User { get; }

        public LogItem(string itemNo, string name, string date, string operation, string amount, string user)
        {
            ItemNo = itemNo;
            Name = name;
            Date = date;
            Operation = operation;
            Amount = amount;
            User = user;
        }

        public override string ToString()
        {
            return $"{Date} {Operation} {Amount} {User}";
        }

    }
}
