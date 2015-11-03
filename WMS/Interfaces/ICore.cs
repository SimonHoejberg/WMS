using System;
using System.Collections.Generic;
using WMS.Core;
using MySql.Data.MySqlClient;

namespace WMS.Interfaces
{
    public interface ICore
    {

        void OpenInformation();

        void OpenLog();

        void OpenLog(string itemNo);

        void OpenMove();

        void OpenRegister();

        void OpenReduce();

        void OpenWaste();
        MySqlDataAdapter GetInfoForReduce(string itemNo);
        List<object> dataToList(string db);

        void UpdateProduct(string coloumn, string value, string id, string db);

        MySqlDataAdapter getData(string db);

        MySqlDataAdapter GetDataFromItemNo(string itemNo,string db);

        void Run();

        void Update(object caller);

    }
}
