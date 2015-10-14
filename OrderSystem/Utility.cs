using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace OrderSystem
{
    class Utility
    {
        public string HandleSQLError(SqlException ex)
        {
            return ("An SQL error occured: " + ex.Message);
        }
        public string HandleException(Exception ex)
        {
            if (ex is SqlException)
            {
                SqlException mySqlException = ex as SqlException;
                return HandleSQLError(mySqlException);
            }
            else
            {
                return "Please make sure that no fields are empty";
            }
        }
    }
}
