using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Core
{
    public class UserData
    {
        private Dictionary<int, string> user_data;

        public UserData()
        {
            user_data = new Dictionary<int, string>();
            user_data.Add(1234, "Louise Taber"); //Test person. In the final program, the people will be stored on the database.
        }

        public bool doesUserExist(int a)
        {
            return user_data.ContainsKey(a);
        }

        public string getUserNameFromID(int a)
        {
            string val;
            user_data.TryGetValue(a, out val);
            return val;            
        }
        
    }
}
