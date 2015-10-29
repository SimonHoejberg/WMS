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

        void OpenMove();

        void OpenRegister();

        void OpenReduce();

        void OpenWaste();

        List<object> dataToList(string db);

        void UpdateProduct(string coloumn, string value, string id, string db);

        [Obsolete("Use getData instead")]
        MySqlDataAdapter getInfo();

        [Obsolete("Use getData instead")]
        MySqlDataAdapter getLog();

        MySqlDataAdapter getData(string db);

        void Run();

        void Update(object caller);

        UserData getUserDataObj();
    }
}
