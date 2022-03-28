using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoneksiDB.Entity
{
    class EntStaff
    {
        private String kodeStaff;
        private String namaStaff;
        private String jabatan;
        private String password;

        public void setKodeStaff(String kode)
        {
            kodeStaff = kode;
        }

        public String getKode()
        {
            return kodeStaff;
        }

        public void setNamaStaff(String nama)
        {
            namaStaff = nama;
        }

        public String getNama()
        {
            return namaStaff;
        }

        public void setJabatan(String jbt)
        {
            jabatan = jbt;
        }

        public String getJabatan()
        {
            return jabatan;
        }

        public void setPassword(String pwd)
        {
            password = pwd;
        }

        public String getPassword()
        {
            return password;
        }
    }
}
