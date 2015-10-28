using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.FindClass
{

    List<item> ItemList = new List<item>();
    public void LoadItemList()
    {

    }
    




    public item Find_item(string name)
    {
        foreach(item in Itemlist)
        {
            if (name.Equals(ItemList.name))
            {
                return item;
            }
        }
        return null;

        //methoder til at finde list over item eller broken item, return list()
    }
}
