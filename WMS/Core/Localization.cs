using WMS.WH;

namespace WMS.Core
{
    public class Localization
    {
        enum Shelf
        {
            A1, A2, A3, A4, A5, A6,
            B1, B2, B3, B4, B5, B6
        };

        //public string FastLocalizer (ItemType product)
        //{
        //    return product.LocationShelfUnit.ToString() + ";" + product.LocationShelfDepth.ToString();
        //}

        public string Localizer (Item product)
        {
            return ((Shelf)product.Shelf).ToString() + ";" + product.Space.ToString();
        }

    }
}
