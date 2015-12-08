using MySql.Data.MySqlClient;

namespace WMS.Interfaces
{
    public interface IDataBaseHandler
    {
        MySqlDataReader GetUserName(string userId);

        MySqlDataAdapter GetDataForItemNo(string db, string searchTerm, string itemNo);

        MySqlDataAdapter GetAllDataFromDataBase(string db);

        MySqlDataReader GetItemInfoForTheLog(string db, string searchTerm, string i, string fromLimit, string amount);

        MySqlDataReader GetItemInfo(string db, string searchTerm, string i);

        MySqlDataReader GetItemLatestLog(string itemNo);

        MySqlDataReader GetDataForList(string db);

        void LogOperation(string itemNo, string description, string date, string user, string operation, int amount);

        void UpdateInfo(string id, string itemNo, string quantity, char op, string description, string operation, string user);

        MySqlDataAdapter Search(string itemNo, string db, string searchTerm);

        void moveItem(string Item, string newLocation);

        void moveItem(string id, string newQuantity, string newItem, char op);

        void PlaceItem(string id, string amount, string itemNo, string usage, string newLocation, string orderNo, string description, string user, string operation);

        MySqlDataReader GetMaxShelf();

        MySqlDataReader GetMaxSpace();

        void CloseConnection();

    }
}
