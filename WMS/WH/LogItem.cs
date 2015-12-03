
namespace WMS.WH
{
    /// <summary>
    /// A class that can be made object of that holds the different values from a line in the log for a item 
    /// </summary>
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

        public override string ToString() => $"{Date} {Operation} {Amount} {User}";

    }
}
