using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static hashtagTODO.Models.Projektlist_model;

namespace hashtagTODO.Controllers
{
    class Projektlist_controller
    {
        dbEntities dbE = new dbEntities();
        private static int projektIDs;
        public int projektID { get { return projektIDs; } set { projektIDs = value; } }

        public List<Projektlist_DataSource> Projektlist_FullQuery()
        {
            string query = "SELECT * FROM Projektlist";
            return dbE.Projektlist_Query_SQLite(query);
        }
    }
}
