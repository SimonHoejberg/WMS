using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Interfaces
{
    public interface IWindowHandler : IMenuWindows
    {
        List<IGui> WindowsOpen { get; }

        void Run();
    }
}
