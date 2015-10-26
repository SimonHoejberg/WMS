﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Core;
using MySql;
using MySql.Data.MySqlClient;

namespace WMS.Interfaces
{
    public interface IBridge
    {
        void SetCore(Core.Core core);

        void OpenInformation();

        void OpenLog();

        void OpenMove();

        void OpenRegister();

        void OpenWaste();

        void update(string coloumn, string value, string id);

        MySqlDataAdapter getInfo();

        MySqlDataAdapter getLog();

        void run();
    }
}
