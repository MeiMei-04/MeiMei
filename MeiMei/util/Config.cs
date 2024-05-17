using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeiMei.util
{
    internal class Config
    {
        const string connectString = @"Data Source=EMHIEUDEPTRAI;Initial Catalog=QLCAFEMEIMEI;User ID=sa;Password=123";
        public static string getConnectString()
        {
            return connectString;
        }
    }
}
