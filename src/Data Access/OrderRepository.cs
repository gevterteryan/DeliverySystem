using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Data_Access.Model;
using static Data_Access.EnumeratedProperties.DriverTypeEnum;
using static Data_Access.EnumeratedProperties.OrderPriorityCode;
using System.Threading.Tasks;

namespace Data_Access
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<List<Order>> GetOrdersAsync(bool IsAllOrders = false)
        {
            List<Order> result = new();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = conn;
                    if (IsAllOrders == false)
                        cmd.CommandText = "[dbo].[GetOrders]";
                    else
                        cmd.CommandText = "[dbo].[GetAllOrders]";

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            int ordID = reader.GetOrdinal("ID");
                            int ordDriverType = reader.GetOrdinal("DriverType");
                            int ordDriverID = reader.GetOrdinal("DriverID");
                            int ordDriver = reader.GetOrdinal("DriverName");
                            int ordTotalPrice = reader.GetOrdinal("TotalPrice");
                            int ordRestaurant = reader.GetOrdinal("RestaurantName");
                            int ordOrderAddress = reader.GetOrdinal("OrderAddress");
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordPhoneNumber = reader.GetOrdinal("PhoneNumber");
                            int ordOrdersCount = reader.GetOrdinal("OrdersCount");
                            int ordPriorityCode = reader.GetOrdinal("PriorityCode");
                            int ordOrderStart = reader.GetOrdinal("OrderStart");
                            int ordPlace = reader.GetOrdinal("Place");
                            int ordAssign = reader.GetOrdinal("Assign");
                            int ordPickup = reader.GetOrdinal("Pickup");
                            int ordArrive = reader.GetOrdinal("Arrive");
                            int ordDepart = reader.GetOrdinal("Depart");
                            int ordComplete = reader.GetOrdinal("Complete");

                            while (reader.Read())
                            {
                                result.Add(new Order()
                                {
                                    Id = reader.GetInt32(ordID),
                                    DriverType = reader.IsDBNull(ordDriverType) ? null : (DriverType)reader.GetInt32(ordDriverType),
                                    DriverID = reader.IsDBNull(ordDriverID) ? null : reader.GetInt32(ordDriverID),
                                    DriverName = reader.IsDBNull(ordDriver) ? string.Empty : reader.GetString(ordDriver),
                                    TotalPrice = reader.GetDecimal(ordTotalPrice),
                                    Restaurant = reader.GetString(ordRestaurant),
                                    OrderAddress = reader.GetString(ordOrderAddress),
                                    FirstName = reader.GetString(ordFirstName),
                                    LastName = reader.GetString(ordLastName),
                                    PhoneNumber = reader.GetString(ordPhoneNumber),
                                    UserOrdersCount = reader.IsDBNull(ordOrdersCount) ? null : reader.GetInt32(ordOrdersCount),
                                    PriorityCode = reader.IsDBNull(ordPriorityCode) ? null : (Status)(reader.GetInt32(ordPriorityCode)),
                                    OrderStart = reader.GetDateTime(ordOrderStart),
                                    Place = reader.IsDBNull(ordPlace) ? null : reader.GetDateTime(ordPlace),
                                    Pickup = reader.IsDBNull(ordPickup) ? null : reader.GetDateTime(ordPickup),
                                    Assign = reader.IsDBNull(ordAssign) ? null : reader.GetDateTime(ordAssign),
                                    Arrive = reader.IsDBNull(ordArrive) ? null : reader.GetDateTime(ordArrive),
                                    Depart = reader.IsDBNull(ordDepart) ? null : reader.GetDateTime(ordDepart),
                                    Complete = reader.IsDBNull(ordComplete) ? null : reader.GetDateTime(ordComplete),
                                    /*                                    Detail = orderDetail.Add(new OrderDetail()
                                                                        {
                                                                            ItemCount = reader.IsDBNull


                                                                        }
                                                                        )*/
                                });
                            }
                        }
                    }
                }
            }
            return result;
        }
        public async Task<List<Order>> GetUserOrdersAsync(int UserID)
        {
            List<Order> result = new List<Order>();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[GetUserOrders]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.HasRows)
                        {
                            int ordID = reader.GetOrdinal("ID");
                            int ordDriverType = reader.GetOrdinal("DriverType");
                            int ordDriverID = reader.GetOrdinal("DriverID");
                            int ordDriver = reader.GetOrdinal("DriverName");
                            int ordTotalPrice = reader.GetOrdinal("TotalPrice");
                            int ordRestaurant = reader.GetOrdinal("RestaurantName");
                            int ordOrderAddress = reader.GetOrdinal("OrderAddress");
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordPhoneNumber = reader.GetOrdinal("PhoneNumber");
                            int ordOrdersCount = reader.GetOrdinal("OrdersCount");
                            int ordPriorityCode = reader.GetOrdinal("PriorityCode");
                            int ordOrderStart = reader.GetOrdinal("OrderStart");
                            int ordPlace = reader.GetOrdinal("Place");
                            int ordAssign = reader.GetOrdinal("Assign");
                            int ordPickup = reader.GetOrdinal("Pickup");
                            int ordArrive = reader.GetOrdinal("Arrive");
                            int ordDepart = reader.GetOrdinal("Depart");
                            int ordComplete = reader.GetOrdinal("Complete");

                            while (reader.Read())
                            {
                                result.Add(new Order()
                                {
                                    Id = reader.GetInt32(ordID),
                                    DriverType = reader.IsDBNull(ordDriverType) ? null : (DriverType)reader.GetInt32(ordDriverType),
                                    DriverID = reader.IsDBNull(ordDriverID) ? null : reader.GetInt32(ordDriverID),
                                    DriverName = reader.IsDBNull(ordDriver) ? string.Empty : reader.GetString(ordDriver),
                                    TotalPrice = reader.GetDecimal(ordTotalPrice),
                                    Restaurant = reader.GetString(ordRestaurant),
                                    OrderAddress = reader.GetString(ordOrderAddress),
                                    FirstName = reader.GetString(ordFirstName),
                                    LastName = reader.GetString(ordLastName),
                                    PhoneNumber = reader.GetString(ordPhoneNumber),
                                    UserOrdersCount = reader.IsDBNull(ordOrdersCount) ? null : reader.GetInt32(ordOrdersCount),
                                    PriorityCode = reader.IsDBNull(ordPriorityCode) ? null : (Status)(reader.GetInt32(ordPriorityCode)),
                                    OrderStart = reader.GetDateTime(ordOrderStart),
                                    Place = reader.IsDBNull(ordPlace) ? null : reader.GetDateTime(ordPlace),
                                    Pickup = reader.IsDBNull(ordPickup) ? null : reader.GetDateTime(ordPickup),
                                    Assign = reader.IsDBNull(ordAssign) ? null : reader.GetDateTime(ordAssign),
                                    Arrive = reader.IsDBNull(ordArrive) ? null : reader.GetDateTime(ordArrive),
                                    Depart = reader.IsDBNull(ordDepart) ? null : reader.GetDateTime(ordDepart),
                                    Complete = reader.IsDBNull(ordComplete) ? null : reader.GetDateTime(ordComplete),
                                });
                            }
                        }
                    }
                }
            }
            return result;
        }
        public async Task<Order> UpdateStatusAsync(int ID, int PriorityCode, int? DriverID)
        {
            Order result = new();
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "[dbo].[UpdateStatus]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("@OrderID", System.Data.SqlDbType.Int).Value = ID;
                    cmd.Parameters.Add("@PriorityCode", System.Data.SqlDbType.Int).Value = PriorityCode;
                    cmd.Parameters.Add("@DriverID", System.Data.SqlDbType.Int).Value = DriverID;
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.SingleRow))
                    {
                        if (reader.HasRows)
                        {
                            int ordID = reader.GetOrdinal("ID");
                            int ordDriverType = reader.GetOrdinal("DriverType");
                            int ordDriverID = reader.GetOrdinal("DriverID");
                            int ordDriver = reader.GetOrdinal("DriverName");
                            int ordTotalPrice = reader.GetOrdinal("TotalPrice");
                            int ordRestaurant = reader.GetOrdinal("RestaurantName");
                            int ordOrderAddress = reader.GetOrdinal("OrderAddress");
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordPhoneNumber = reader.GetOrdinal("PhoneNumber");
                            int ordOrdersCount = reader.GetOrdinal("OrdersCount");
                            int ordPriorityCode = reader.GetOrdinal("PriorityCode");
                            int ordOrderStart = reader.GetOrdinal("OrderStart");
                            int ordPlace = reader.GetOrdinal("Place");
                            int ordAssign = reader.GetOrdinal("Assign");
                            int ordPickup = reader.GetOrdinal("Pickup");
                            int ordArrive = reader.GetOrdinal("Arrive");
                            int ordDepart = reader.GetOrdinal("Depart");
                            int ordComplete = reader.GetOrdinal("Complete");

                            while (reader.Read())
                            {

                                result.Id = reader.GetInt32(ordID);
                                result.DriverType = reader.IsDBNull(ordDriverType) ? null : (DriverType)reader.GetInt32(ordDriverType);
                                result.DriverID = reader.IsDBNull(ordDriverID) ? null : reader.GetInt32(ordDriverID);
                                result.DriverName = reader.IsDBNull(ordDriver) ? string.Empty : reader.GetString(ordDriver);
                                result.TotalPrice = reader.GetDecimal(ordTotalPrice);
                                result.Restaurant = reader.GetString(ordRestaurant);
                                result.OrderAddress = reader.GetString(ordOrderAddress);
                                result.FirstName = reader.GetString(ordFirstName);
                                result.LastName = reader.GetString(ordLastName);
                                result.PhoneNumber = reader.GetString(ordPhoneNumber);
                                result.UserOrdersCount = reader.IsDBNull(ordOrdersCount) ? null : reader.GetInt32(ordOrdersCount);
                                result.PriorityCode = (Status)(reader.GetInt32(ordPriorityCode));
                                result.OrderStart = reader.GetDateTime(ordOrderStart);
                                result.Place = reader.IsDBNull(ordPlace) ? null : reader.GetDateTime(ordPlace);
                                result.Pickup = reader.IsDBNull(ordPickup) ? null : reader.GetDateTime(ordPickup);
                                result.Assign = reader.IsDBNull(ordAssign) ? null : reader.GetDateTime(ordAssign);
                                result.Arrive = reader.IsDBNull(ordArrive) ? null : reader.GetDateTime(ordArrive);
                                result.Depart = reader.IsDBNull(ordDepart) ? null : reader.GetDateTime(ordDepart);
                                result.Complete = reader.IsDBNull(ordComplete) ? null : reader.GetDateTime(ordComplete);


                            }
                        }
                    }

                }
            }
            return result;
        }
        public async Task<int> DoOrderAsync(CreateOrder order)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.Connection = conn;

                    cmd.CommandText = "[dbo].[CreateOrder]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = 1;
                    cmd.Parameters.Add("@RestaurantID", System.Data.SqlDbType.Int).Value = order.RestaurantID;
                    cmd.Parameters.Add("@TotalPrice", System.Data.SqlDbType.Decimal).Value = order.TotalPrice;
                    cmd.Parameters.Add("@DeliveryPrice", System.Data.SqlDbType.Decimal).Value = order.DeliveryPrice;
                    cmd.Parameters.Add("@OrderAddress", System.Data.SqlDbType.NVarChar).Value = order.OrderAddress;
                    cmd.Parameters.Add("@PhoneNumber", System.Data.SqlDbType.NVarChar).Value = order.PhoneNumber;/*
                    cmd.Parameters.Add("@OrderDetail", System.Data.SqlDbType.Structured).Value = order.Detail;*/
                    cmd.Parameters.Add("@OrderID", System.Data.SqlDbType.Int).Value = System.Data.ParameterDirection.Output;

                    await cmd.ExecuteReaderAsync();
                    return Convert.ToInt32(cmd.Parameters["@OrderID"].Value);
                }
            }
        }
        public async Task<int> RateOrderAsync(int OrderID, decimal OrderRating)
        {
            using (SqlConnection conn = ConnectionManager.CreateConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new())
                {
                    cmd.CommandText = "[dbo].[RateOrder]";
                    cmd.Parameters.Add("@OrderID", System.Data.SqlDbType.Int).Value = OrderID;
                    cmd.Parameters.Add("@OrderRating", System.Data.SqlDbType.Decimal).Value = OrderRating;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    return await cmd.ExecuteNonQueryAsync();

                }
            }
        }
    }
}