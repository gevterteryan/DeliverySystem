using Data_Access.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data_Access
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            List<Restaurant> result = new List<Restaurant>();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[GetRestaurants]";
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            int ordID = reader.GetOrdinal("ID");
                            int ordCatID = reader.GetOrdinal("CatID");
                            int ordName = reader.GetOrdinal("Name");
                            int ordCatName = reader.GetOrdinal("CatName");
                            int ordDeliveryPrice = reader.GetOrdinal("DeliveryPrice");
                            int ordOpeningDate = reader.GetOrdinal("OpeningDate");
                            int ordClosingDate = reader.GetOrdinal("ClosingDate");
                            int ordRating = reader.GetOrdinal("Rating");

                            while (reader.Read())
                            {
                                result.Add(new Restaurant()
                                {
                                    Id = reader.GetInt32(ordID),
                                    CatID = reader.GetInt32(ordCatID),
                                    Name = reader.GetString(ordName),
                                    CatName = reader.GetString(ordCatName),
                                    DeliveryPrice = reader.IsDBNull(ordDeliveryPrice) ? null : reader.GetDecimal(ordDeliveryPrice),
                                    OpeningDate = reader.GetTimeSpan(ordOpeningDate).ToString().Substring(0,5),
                                    ClosedDate = reader.GetTimeSpan(ordClosingDate).ToString().Substring(0, 5),
                                    Rating = reader.IsDBNull(ordRating) ? null : reader.GetDecimal(ordRating),
                                });
                            }
                        }
                    }
                }
            }
            return result;
        }
        public async Task<List<RestaurantMenu>> GetRestaurantMenuAsync(int RestId)
        {
            List<RestaurantMenu> result = new List<RestaurantMenu>();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[GetRestaurantMenu]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RestaurantID", System.Data.SqlDbType.Int).Value = RestId;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            int ordID = reader.GetOrdinal("ID");
                            int ordRestID = reader.GetOrdinal("RestID");
                            int ordCatID = reader.GetOrdinal("ItemCatID");
                            int ordName = reader.GetOrdinal("Name");
                            int ordDescription = reader.GetOrdinal("Description");
                            int ordPrice = reader.GetOrdinal("Price");

                            while (reader.Read())
                            {
                                result.Add(new RestaurantMenu()
                                {
                                    Id = reader.GetInt32(ordID),
                                    RestID = reader.GetInt32(ordRestID),
                                    CatID = reader.GetInt32(ordCatID),
                                    Name = reader.GetString(ordName),
                                    Description = reader.GetString(ordDescription),
                                    Price = reader.GetDecimal(ordPrice)
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
