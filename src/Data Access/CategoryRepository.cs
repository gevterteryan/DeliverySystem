using Data_Access.Model;
using Data_Access.ReposInterfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data_Access
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> result = new List<Category>();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[GetCategories]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            int ordID = reader.GetOrdinal("ID");
                            int ordCatName = reader.GetOrdinal("CatName");
                            while (reader.Read())
                            {
                                result.Add(new Category()
                                {
                                    Id = reader.GetInt32(ordID),
                                    CatName = reader.GetString(ordCatName)
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