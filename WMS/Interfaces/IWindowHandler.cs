using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Interfaces
{
    public interface IWindowHandler
    {
        List<IGui> WindowsOpen { get; }

        void Run();

        void OpenInformation();

        void OpenLog();

        void OpenLog(string itemNo);

        void OpenMove();

        void OpenRegister();

        void OpenReduce();

        void OpenWaste();


    }
}
