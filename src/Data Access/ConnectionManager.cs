using System;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Data_Access
{
    public static class ConnectionManager
    {
        public static SqlConnection CreateConnection(string userId= "",string password ="")
        {
/*           SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"(LocalDB)\LocalDBDemo";
            builder.InitialCatalog = "DeliverySystem";
            if (string.IsNullOrEmpty(userId) && string.IsNullOrEmpty(password))
                builder.IntegratedSecurity = true;
            else
            {
                builder.IntegratedSecurity = false;
                builder.UserID = userId;
                builder.Password = password;
            }
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = builder.ConnectionString;
            return conn;*/

            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder("Data Source=SQL8001.site4now.net;Initial Catalog=db_a84c02_deliverysystem;User Id=db_a84c02_deliverysystem_admin;Password=armsoftdiplomayin1");
            sqlConnectionStringBuilder.MultipleActiveResultSets = true;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = sqlConnectionStringBuilder.ConnectionString;
            return conn; 
        }
    }
}
