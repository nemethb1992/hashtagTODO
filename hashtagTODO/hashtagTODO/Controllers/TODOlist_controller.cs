using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hashtagTODO.Models.TODOlist_model;

namespace hashtagTODO.Controllers
{
    class TODOlist_controller
    {
        dbEntities dbE = new dbEntities();
        Projektlist_controller proj_control = new Projektlist_controller();

        public List<TODOlist_DataSource> TODOlist_FullQuery()
        {
            string query = "SELECT * FROM TODOlist INNER JOIN projekt_todo_kapcs ON projekt_todo_kapcs.id_todo = TODOlist.id WHERE id_projekt = " + proj_control.projektID + "";
            return dbE.TODOlist_Query_SQLite(query);
        }
        public void InnerDb_Structure_BuildUp()
        {
            string query1 = "CREATE TABLE IF NOT EXISTS `TODOlist` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT, `n_projekt` TEXT, `n_feladat` TEXT, `allapot` INTEGER DEFAULT 0 )";
            string query2 = "CREATE TABLE IF NOT EXISTS `projekt_todo_kapcs` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT, `id_todo` INTEGER, `id_projekt` INTEGER )";
            string query3 = "CREATE TABLE IF NOT EXISTS `Projektlist` ( `id` INTEGER PRIMARY KEY AUTOINCREMENT, `n_projekt` TEXT, `allapot` INTEGER DEFAULT 0 )";
            dbE.SqliteQueryExecute(query1);
            dbE.SqliteQueryExecute(query2);
            dbE.SqliteQueryExecute(query3);
        }
    }
}
