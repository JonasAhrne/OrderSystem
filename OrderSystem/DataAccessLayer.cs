using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace OrderSystem
{
    class DataAccessLayer
    {
        SqlConnection connection = new SqlConnection("Server=LocalHost;Database=Ordersystem;Trusted_Connection=True;");
        SqlCommand cmd = new SqlCommand();


        //Customer
        internal void SearchCustomer(string CustomerSearch, DataSet Ds)
        {

            using (SqlCommand cmd = new SqlCommand("dbo.usp_SelectCustomers", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cNbr", SqlDbType.VarChar).Value = CustomerSearch;
                cmd.Parameters.Add("@cFirstName", SqlDbType.VarChar).Value = CustomerSearch;
                cmd.Parameters.Add("@cLastName", SqlDbType.VarChar).Value = CustomerSearch;

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(Ds);
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        internal void PopulateCustomer(string CustomerSsn, DataSet Ds)
        {
            using (SqlCommand cmd = new SqlCommand("dbo.usp_SelectCustomers", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cNbr", SqlDbType.VarChar).Value = CustomerSsn;
                cmd.Parameters.Add("@cFirstName", SqlDbType.VarChar).Value = CustomerSsn;
                cmd.Parameters.Add("@cLastName", SqlDbType.VarChar).Value = CustomerSsn;

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(Ds);
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }

            }
        }
        internal void CreateCustomer(string[] CustomerData)
        {

            using (SqlCommand cmd = new SqlCommand("dbo.usp_InsertCustomer", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cNbr", SqlDbType.VarChar).Value = CustomerData[0];
                cmd.Parameters.Add("@cFirstName", SqlDbType.VarChar).Value = CustomerData[1];
                cmd.Parameters.Add("@cLastName", SqlDbType.VarChar).Value = CustomerData[2];
                cmd.Parameters.Add("@cMail", SqlDbType.VarChar).Value = CustomerData[3];
                cmd.Parameters.Add("@cAdress", SqlDbType.VarChar).Value = CustomerData[4];
                cmd.Parameters.Add("@cPhoneNbr", SqlDbType.VarChar).Value = CustomerData[5];
                cmd.Parameters.Add("@cCity", SqlDbType.VarChar).Value = CustomerData[6];
                cmd.Parameters.Add("@cPostalcode", SqlDbType.VarChar).Value = CustomerData[7];

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();

                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        internal void DeleteCustomer(string Ssn)
        {
            using (SqlCommand cmd = new SqlCommand("dbo.usp_DeleteCustomer", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cNbr", SqlDbType.VarChar).Value = Ssn;

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        internal void UpdateCustomer(string[] CustomerData)
        {

            using (SqlCommand cmd = new SqlCommand("dbo.usp_UpdateCustomer", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@cNbr", SqlDbType.VarChar).Value = CustomerData[0];
                cmd.Parameters.Add("@cFirstName", SqlDbType.VarChar).Value = CustomerData[1];
                cmd.Parameters.Add("@cLastName", SqlDbType.VarChar).Value = CustomerData[2];
                cmd.Parameters.Add("@cMail", SqlDbType.VarChar).Value = CustomerData[3];
                cmd.Parameters.Add("@cAdress", SqlDbType.VarChar).Value = CustomerData[4];
                cmd.Parameters.Add("@cPhoneNbr", SqlDbType.VarChar).Value = CustomerData[5];
                cmd.Parameters.Add("@cCity", SqlDbType.VarChar).Value = CustomerData[6];
                cmd.Parameters.Add("@cPostalcode", SqlDbType.VarChar).Value = CustomerData[7];

                connection.Open();


                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //Product
        internal void SearchProduct(string ProductSearch, DataSet Ds)
        {

            using (SqlCommand cmd = new SqlCommand("dbo.usp_SelectProducts", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pNbr", SqlDbType.VarChar).Value = ProductSearch;
                cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = ProductSearch;

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(Ds);
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        internal void CreateProduct(string[] ProductData)
        {
            using (SqlCommand cmd = new SqlCommand("dbo.usp_InsertProduct", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pNbr", SqlDbType.VarChar).Value = ProductData[0];
                cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = ProductData[1];
                cmd.Parameters.Add("@pStock", SqlDbType.VarChar).Value = ProductData[2];
                cmd.Parameters.Add("@pPrice", SqlDbType.VarChar).Value = ProductData[3];

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        internal void DeleteProduct(string ProductNbr)
        {

            using (SqlCommand cmd = new SqlCommand("dbo.usp_DeleteProduct", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pNbr", SqlDbType.VarChar).Value = ProductNbr;

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        internal void UpdateProduct(string[] ProductData)
        {
            using (SqlCommand cmd = new SqlCommand("dbo.usp_UpdateProduct", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pNbr", SqlDbType.VarChar).Value = ProductData[0];
                cmd.Parameters.Add("@pName", SqlDbType.VarChar).Value = ProductData[1];
                cmd.Parameters.Add("@pStock", SqlDbType.VarChar).Value = ProductData[2];
                cmd.Parameters.Add("@pPrice", SqlDbType.VarChar).Value = ProductData[3];

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        internal void PopulateProduct(string ProductNbr, DataSet Ds)
        {

            connection.Open();
            try
            {
                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Product WHERE pNbr = '" + ProductNbr + "'", connection);
                Adapter.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                connection.Close();
            }
        }

        //Order
        internal void SearchOrder(string OrderSearch, DataSet Ds)
        {

            using (SqlCommand cmd = new SqlCommand("dbo.usp_SelectOrder", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@oNbr", SqlDbType.VarChar).Value = OrderSearch;
                cmd.Parameters.Add("@cNbr", SqlDbType.VarChar).Value = OrderSearch;

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    SqlDataAdapter Adapter = new SqlDataAdapter();
                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(Ds);
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        internal void SearchOrderrow(string OrderNbr, DataSet Ds)
        {
            using (SqlCommand cmd = new SqlCommand("dbo.usp_SelectOrderrow", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@oNbr", SqlDbType.VarChar).Value = OrderNbr;

                SqlDataAdapter Adapter = new SqlDataAdapter();
                try
                {
                    connection.Open();
                    Adapter.SelectCommand = cmd;
                    Adapter.Fill(Ds);
                    connection.Close();

                }
                catch (Exception Ex)
                {
                    throw Ex;
                }
            }
        }

        internal void CreateOrder(string[] OrderData)
        {

            using (SqlCommand cmd = new SqlCommand("dbo.usp_InsertOrder", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@oNbr", SqlDbType.VarChar).Value = OrderData[0];
                cmd.Parameters.Add("@oDate", SqlDbType.VarChar).Value = OrderData[1];
                cmd.Parameters.Add("@oTotalprice", SqlDbType.VarChar).Value = OrderData[2];
                cmd.Parameters.Add("@cNbr", SqlDbType.VarChar).Value = OrderData[3];

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        internal void CreateOrderrow(string[] OrderrowData)
        {

            using (SqlCommand cmd = new SqlCommand("dbo.usp_InsertOrderrow", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@pNbr", SqlDbType.VarChar).Value = OrderrowData[0];
                cmd.Parameters.Add("@oNbr", SqlDbType.VarChar).Value = OrderrowData[1];
                cmd.Parameters.Add("@oAmount", SqlDbType.VarChar).Value = OrderrowData[2];
                cmd.Parameters.Add("@oTotalprice", SqlDbType.VarChar).Value = OrderrowData[3];

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();

                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        internal void DeleteOrder(string OrderNbr)
        {
            using (SqlCommand cmd = new SqlCommand("dbo.usp_DeleteOrder", connection))
            {
                SqlTransaction myTrans;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@oNbr", SqlDbType.VarChar).Value = OrderNbr;

                connection.Open();

                myTrans = connection.BeginTransaction();
                cmd.Transaction = myTrans;
                try
                {
                    cmd.ExecuteNonQuery();
                    myTrans.Commit();
                }
                catch (Exception Ex)
                {
                    myTrans.Rollback();
                    throw Ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        internal int GetOrderNbr()
        {
            connection.Open();
            try
            {
                cmd = new SqlCommand("SELECT TOP 1 oNbr FROM [Order] ORDER BY oNbr DESC", connection);
                string HighestOrderNbr = (string)cmd.ExecuteScalar();

                int NewOrderNbr = Convert.ToInt32(HighestOrderNbr) + 1;
                return NewOrderNbr;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                connection.Close();
            }
        }

        internal void AddProduct(string ProductNbr, DataSet Ds)
        {
            connection.Open();
            try
            {
                SqlDataAdapter Adapter = new SqlDataAdapter("SELECT * FROM Product WHERE pNbr = '" + ProductNbr + "'", connection);
                Adapter.Fill(Ds);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
