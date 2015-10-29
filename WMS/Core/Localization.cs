using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Warehouse;

namespace WMS.Core
{
    public class Localization
    {
        enum Shelf
        {
            A1, A2, A3, A4, A5, A6,
            B1, B2, B3, B4, B5, B6
        };

        public string FastLocalizer (ItemType product)
        {
            return product.LocationShelfUnit.ToString() + ";" + product.LocationShelfHeight.ToString();
        }

        public string Localizer (ItemType product)
        {
            return ((Shelf)product.LocationShelfUnit).ToString() + ";" + product.LocationShelfHeight.ToString();
        }

    }
}
