using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace KoneksiDB.KoneksiDB
{
    class Koneksi
    {
        public static MySqlConnection getKoneksi()
        {
            string strCon = "SERVER = localhost; PORT = 3306; " +
                "UID = root; PWD = ; " +
                "DATABASE = login_staff;";
            return new MySqlConnection(strCon);
        }
    }
}
