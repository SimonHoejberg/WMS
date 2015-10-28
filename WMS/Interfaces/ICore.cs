using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Core;
using MySql;
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
    }
}
