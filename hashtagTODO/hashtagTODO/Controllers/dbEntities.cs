using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static hashtagTODO.Models.Projektlist_model;
using static hashtagTODO.Models.TODOlist_model;

namespace hashtagTODO.Controllers
{
    class dbEntities
    {
        private SQLiteConnection conn;
        private SQLiteDataReader sdr;
        public dbEntities()
        {
            SetupDB();
        }
        private void SetupDB()
        {
            string connectionString = "Data Source = InnerDb.db";
            conn = new SQLiteConnection(connectionString);
        }
        public bool dbOpen()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
        private bool dbClose()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public void SqliteQueryExecute(string query)
        {
            if (this.dbOpen() == true)
            {
                var command = conn.CreateCommand();
                command.CommandText = query;
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        // SPEC Lister Querys

        public string SqliteReaderExecute(string query)
        {
            string data = "";
            if (this.dbOpen() == true)
            {
                var command = conn.CreateCommand();
                command.CommandText = query;
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    data = sdr.GetValue(0).ToString();
                }
                sdr.Close();
            }
            conn.Close();
            return data;
        }
        public List<TODOlist_DataSource> TODOlist_Query_SQLite(string query)
        {

            List<TODOlist_DataSource> list = new List<TODOlist_DataSource>();
            if (this.dbOpen() == true)
            {
                var command = conn.CreateCommand();
                command.CommandText = query;
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new TODOlist_DataSource
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        n_projekt = sdr["n_projekt"].ToString(),
                        n_feladat = sdr["n_feladat"].ToString(),
                        allapot = Convert.ToInt32(sdr["allapot"]),
                    });
                }
                sdr.Close();
            }
            dbClose();
            
            return list;
        }
        public List<Projektlist_DataSource> Projektlist_Query_SQLite(string query)
        {

            List<Projektlist_DataSource> list = new List<Projektlist_DataSource>();
            if (this.dbOpen() == true)
            {
                var command = conn.CreateCommand();
                command.CommandText = query;
                sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    list.Add(new Projektlist_DataSource
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        n_projekt = sdr["n_projekt"].ToString(),
                        allapot = Convert.ToInt32(sdr["allapot"]),
                    });
                }
                sdr.Close();
            }
            dbClose();

            return list;
        }
    }
}
