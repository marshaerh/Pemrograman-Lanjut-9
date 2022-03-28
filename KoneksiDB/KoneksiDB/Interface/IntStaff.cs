using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoneksiDB.Interface
{
    interface IntStaff
    {
        String KodeBaru();
        Boolean InsertStaff(Entity.EntStaff e);
        Boolean UpdateStaff(Entity.EntStaff e);
        Boolean DeleteStaff(String kode);
        DataSet SelectStaff();

        Boolean login_staff(String kode, String password);
    }
}
