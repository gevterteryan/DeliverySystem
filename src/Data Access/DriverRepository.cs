using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using static Data_Access.EnumeratedProperties.DriverTypeEnum;

namespace Data_Access
{
    public class DriverRepository
    {
        public  List<Driver> GetDrivers()
        {
            List<Driver> result = new List<Driver>();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[GetDrivers]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ordID = reader.GetOrdinal("ID");
                            int ordDriverType = reader.GetOrdinal("DriverType");
/*                          int ordAssinedOrderCount = reader.GetOrdinal("AssignedOrderCount");
                            int ordLastOrderAddress = reader.GetOrdinal("LastOrderAddress");*/
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordAge = reader.GetOrdinal("Age");
                            int ordIsActive = reader.GetOrdinal("IsActive");

                            while (reader.Read())
                            {
                                result.Add(new Driver()
                                {
                                    Id = reader.GetInt32(ordID),
                                    Type = (DriverType)reader.GetInt32(ordDriverType),
/*                                  AssinedOrderCount = reader.IsDBNull(ordAssinedOrderCount) ? 0 : reader.GetInt32(ordAssinedOrderCount),
                                    LastOrderAddress = reader.IsDBNull(ordLastOrderAddress) ? String.Empty : reader.GetString(ordLastOrderAddress),*/
                                    FirstName = reader.GetString(ordFirstName),
                                    LastName = reader.GetString(ordLastName),
                                    Age = reader.GetDateTime(ordAge),
                                    IsActive = reader.GetBoolean(ordIsActive),
                                });
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
