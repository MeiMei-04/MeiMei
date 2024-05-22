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
        const string namefileWeb = @"\index.html";
        const string urlfileweb = @"C:\Users\Hieu\Desktop\MeiMei\web" + namefileWeb;
        public static string getConnectString()
        {
            return connectString;
        }
        public static string geturlfileWeb() {
            return urlfileweb;
        }
    }
}
