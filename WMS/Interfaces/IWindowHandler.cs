using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Interfaces
{
    public interface IWindowHandler : IMenuWindows
    {
        void Update(object caller);

        void Run();

        void Exit(string error);

        void ChangeLang(ILang lang);
    }
}
