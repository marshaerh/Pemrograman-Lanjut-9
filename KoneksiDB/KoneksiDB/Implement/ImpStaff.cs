using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using KoneksiDB.Entity;

namespace KoneksiDB.Implement
{
    class ImpStaff : Interface.IntStaff
    {
        private String query;
        private Boolean status;
        private MySqlConnection koneksi;
        private MySqlCommand command;
        private MySqlDataReader reader;

        public ImpStaff()
        {
            koneksi = KoneksiDB.Koneksi.getKoneksi();
        }

        public String KodeBaru()
        {
            int kode = 0;
            string kodeBaru = "";
            try
            {
                query = "SELECT MAX(RIGHT(id_staff,2)) FROM tb_staff";

                koneksi.Open();
                command = koneksi.CreateCommand();
                command.CommandText = query;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    kode = Int16.Parse(reader.GetString(0).ToString());
                    if (kode < 10)
                    {
                        kodeBaru = "ST-0" + (kode + 1);

                    }
                    else
                    {
                        kodeBaru = "ST-" + (kode + 1);
                    }
                }
                koneksi.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR " + ex);
            }
            return kodeBaru;
        }

        public Boolean InsertStaff(Entity.EntStaff e)
        {
            status = false;
            try
            {
                query = "INSERT INTO tb_staff " +
                    "VALUES ('" + e.getKode() + "'," +
                    " '" + e.getNama() + "', " +
                    "'" + e.getJabatan() + "', " +
                    "'" + e.getPassword() + "')";

                koneksi.Open();
                command = koneksi.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR " + ex);
            }
            return status;
        }
        public Boolean UpdateStaff(Entity.EntStaff e)
        {
            status = false;
            try
            {
                query = "UPDATE tb_staff " +
                    "SET nama_staff = '" + e.getNama() + "', " +
                    "jabatan = '" + e.getJabatan() + "', " +
                    "password = '" + e.getPassword() + "' " +
                    "WHERE id_staff = '" + e.getKode() + "'";

                koneksi.Open();
                command = koneksi.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR " + ex);
            }
            return status;
        }
        public Boolean DeleteStaff(String kode)
        {
            status = false;
            try
            {
                query = "DELETE FROM tb_staff WHERE id_staff = '" + kode + "'";

                koneksi.Open();
                command = koneksi.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
                status = true;
                koneksi.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR " + ex);
            }
            return status;
        }
        public DataSet SelectStaff()
        {
            DataSet ds = new DataSet();
            try
            {
                koneksi.Open();
                query = "SELECT * FROM tb_staff";
                command = new MySqlCommand(query, koneksi);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                command.ExecuteNonQuery();
                adapter.Fill(ds, "tb_staff");

                koneksi.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("ERROR " + ex);
            }
            return ds;
        }

        public Boolean LoginStaff(String kode, String password)
        {
            query = "SELECT id_staff, password " +
                "FROM  tb_staff " +
                "WHERE id_staff = '" + kode + "' AND PASSWORD = '" + password + "'"; //query untuk mengambil data dari table tb_staff 

            koneksi.Open(); //digunakan untuk memulai koneksi ke database

            MySqlCommand command = koneksi.CreateCommand(); //digunakan untuk memanggil fungsi pembuat perintah
            command.CommandText = query; //memasukan query dari varibel query ke dalam command
            MySqlDataReader reader = command.ExecuteReader(); //digunakan untuk memanggil data

            while (reader.Read())
            {
                if ((reader.GetString(0).ToString() == kode)
                    && (reader.GetString(1).ToString() == password)) //digunakan untuk memeriksa apakah kode dan password sama dengan database
                {
                    status = true; //jika sama maka akan mengembalikan status true
                }
                else
                {
                    status = false; //jika tidak sama maka akan mengembalikan status false
                }
            }

            koneksi.Close(); //digunakan untuk menutup koneksi ke database

            return status; //digunakan untuk mengembalikan status
        }

        public bool login_staff(string kode, string password)
        {
            throw new NotImplementedException();
        }
    }
}
