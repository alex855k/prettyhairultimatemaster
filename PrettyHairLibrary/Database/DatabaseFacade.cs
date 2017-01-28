using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PrettyHairLibrary.Database
{
    public class DatabaseFacade
    {
        private static volatile DatabaseFacade instance;
        ProductTypeRepository prRep = ProductTypeRepository.Instance;
        //private DatabaseConnection DBCon = DatabaseConnection.Instance;
        private static string connectionString =
    "Server=ealdb1.eal.local; Database=ejl81_db; User Id=ejl81_usr; Password=Baz1nga81;";
        public static DatabaseFacade Instance
        {
            get {
                if (instance == null) {
                    instance = new DatabaseFacade();
                    }
                return instance;

            }
        }

        public void LoadProductTypes()
        {
            string query = "SELECT Description, Price, Amount, ProductId FROM ProductType";
            DataSet dataSet = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
               
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection))
                        {
                            dataAdapter.Fill(dataSet);
                        }

                   
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
            
            foreach (DataTable dt in dataSet.Tables)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    prRep.Add(new ProductType(dr.Field<int>("ProductId"), dr.Field<string>("Description"),(double)dr.Field<int>("Price"), 
                        dr.Field<int>("Amount")));

                }
            }

        }
        public void LoadOrders() {

        }

        private void LoadOrderLines() {

        }
        public void SaveOrder(Order o)
        {
            string query = "INSERT INTO ORDERR (DeliveryDate,OrderDate,OrderId,ProcessStatus) VALUES (@DeliverDate, @OrderDate, @OrderId, @ProcessStatus)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add(new SqlParameter("@OrderId", o.OrderId));
                        cmd.Parameters.Add(new SqlParameter("@DeliveryDate", o.DeliveryDate));
                        cmd.Parameters.Add(new SqlParameter("@OrderDate", o.OrderDate));
                        cmd.Parameters.Add(new SqlParameter("@ProcessStatus", o.ProcessStatus.ToString()));


                        // execute the command
                        try
                        {
                            cmd.ExecuteNonQuery();
              
                        }
                        catch
                        {
                            Debug.WriteLine("Failure to add order.");
                        }

                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }

            //using (SqlConnection connection = new SqlConnection(connectionString))
            {

            }
        }

        public void SaveProductType(ProductType p)
        {
            string query = "INSERT INTO PRODUCT (Description, Price, Amount, ProductId) VALUES (@Description, @Price, @Amount, @ProductId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        SqlCommand cmd = new SqlCommand(query, conn);

                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.Add(new SqlParameter("@ProductId", p.ID));
                        cmd.Parameters.Add(new SqlParameter("@Amount", p.Amount));
                        cmd.Parameters.Add(new SqlParameter("@Price", p.Price));
                        cmd.Parameters.Add(new SqlParameter("@Description", p.Description));


                        // execute the command
                        try
                        {
                            cmd.ExecuteNonQuery();

                        }
                        catch
                        {
                            Debug.WriteLine("Failure to add order.");
                        }

                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }
    }
}
