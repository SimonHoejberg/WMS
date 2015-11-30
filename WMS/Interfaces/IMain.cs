using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Interfaces
{
    public interface IMain
    {
        ICore Core { set; }

        void UpdatePics(bool da);

        void UpdateLang();
    }
}
