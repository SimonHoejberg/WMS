using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.FindClass
{
    List<location> LocationList = new List<location>();



    public int Find_Place(string name)
    {
        foreach(location in LocationList)
        {
            if (name.Equals(locationList.name))
            {
                return Location;
            }
        }

    }
}
