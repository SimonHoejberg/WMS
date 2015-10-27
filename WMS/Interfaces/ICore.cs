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

        void OpenWaste();

        void UpdateProduct(string coloumn, string value, string id);

        MySqlDataAdapter getInfo();

        MySqlDataAdapter getLog();

        void Run();

        void Update();
    }
}
