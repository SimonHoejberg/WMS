﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Interfaces
{
    public interface IGui
    {
        void UpdateGuiElements();

        string GetTypeOfWindow();
    }
}
