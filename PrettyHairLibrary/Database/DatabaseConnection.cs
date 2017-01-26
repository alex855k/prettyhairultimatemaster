using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary.Database
{
    public class DatabaseConnection
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        private static volatile DatabaseConnection instance;
        //private string connectionString =
   // "Server="+ ServerName+"; Database=ejl81_db; User Id=ejl81_usr; Password=Baz1nga81;";
        private DatabaseConnection() {
            ServerName = "ealdb1.eal.local";
        }

        public DatabaseConnection Instance{
            get{
                if (instance == null) instance = new DatabaseConnection();
                return instance; }
        }


    }
}
