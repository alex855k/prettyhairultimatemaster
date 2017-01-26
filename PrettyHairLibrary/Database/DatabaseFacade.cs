using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PrettyHairLibrary.Database
{
    public class DatabaseFacade
    {
        private static volatile DatabaseFacade instance;
        //private DatabaseConnection DBCon = DatabaseConnection.Instance;
        private static string connectionString =
    "Server=ealdb1.eal.local; Database=ejl81_db; User Id=ejl81_usr; Password=Baz1nga81;";
        public static DatabaseFacade Instance
        {
            get {
                if (Instance == null) {
                    instance = new DatabaseFacade();
                    }
                return instance;

            }
        }

        public void executeTheory(string query) {

        }
        public void SaveOrder(Order o)
        {
            string query = "INSERT INTO ORDERR from table";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand("InsertIntoTeacher", conn);

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@TeacherUsername", t.Username));
                        cmd.Parameters.Add(new SqlParameter("@TeacherPassword", t.Password));
                        cmd.Parameters.Add(new SqlParameter("@TeacherFirstName", t.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@TeacherLastName", t.LastName));


                        // execute the command
                        try
                        {
                            cmd.ExecuteNonQuery();
              
                        }
                        catch
                        {
                            Debug.WriteLine("Failure to add teacher.");
                        }

                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        public void SaveOrder(Order o)
        {

        }
            //instance variables
            /*private EntityTable engines;
            //private AbstractEntityPersistenceStrategy persistenceStrategy;
            public event EventHandler EngineAdded;
            public event EventHandler EnginesRestored;

            //private constructor
            private DatabaseFacade() {
                engines = new EntityTable(EntityKeyGenerator.Instance);
               // engines.EntityTableItemAdded += HandleEngineAdded;
                //engines.EntityTableRestored += HandleEngineRestored;

                // Set strategy
                //persistenceStrategy = new EntitySerializationStrategy();

            }
            */
        }
}
