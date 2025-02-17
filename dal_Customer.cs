using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CustomerManageSystem_DTO;
using Microsoft.Data.SqlClient; 
using Microsoft.Extensions.Configuration;
using CustomerManageSystem_Model;

namespace CustomerManageSystem_DAL
{
    public class Dal_Customer
    {
         private readonly string _connectionString;

        public Dal_Customer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("sqlConnect"); 
        }
        public async Task<List<CustomerDto>> GetCustomersAsync(string mode)
        {
            var customers = new List<CustomerDto>();

            using (var cnn = new SqlConnection(_connectionString))
            {
                try
                {
                    await cnn.OpenAsync();
                    using (var cmd = new SqlCommand("customerDetails", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Mode", mode);

                        var errorIdParam = new SqlParameter("@Error_id", SqlDbType.VarChar, 10)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(errorIdParam);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var customer = new CustomerDto
                                {
                                    CustomerCode = reader.GetInt32(reader.GetOrdinal("CustomerCode")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Address = reader.GetString(reader.GetOrdinal("Address")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    MobileNo = reader.GetString(reader.GetOrdinal("MobileNo")),
                                    GeoLocation = reader.GetString(reader.GetOrdinal("GeoLocation"))
                                };

                                customers.Add(customer);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An error occurred while fetching customer details.", ex);
                }
            }

            return customers;
        }

        public async Task<string> InsertUpdateCustomerAsync(string Mode, CustomerDto customer)
        {
            using (var cnn = new SqlConnection(_connectionString))
            {
                try
                {
                    await cnn.OpenAsync();
                    using (var cmd = new SqlCommand("customerDetails", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@mode", Mode);
                        cmd.Parameters.AddWithValue("@CustomerCode", customer.CustomerCode);
                        cmd.Parameters.AddWithValue("@Name", customer.Name);
                        cmd.Parameters.AddWithValue("@Address", customer.Address);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);
                        cmd.Parameters.AddWithValue("@MobileNo", customer.MobileNo);
                        cmd.Parameters.AddWithValue("@GeoLocation", customer.GeoLocation);

                        var errorIdParam = new SqlParameter("@Error_id", SqlDbType.VarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(errorIdParam);

                        await cmd.ExecuteNonQueryAsync();

                        string errorId = errorIdParam.Value?.ToString() ?? "Unknown";
                        return errorId;
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An error occurred while updating customer details.", ex);
                }
            }
        }

        public async Task<string> DeleteCustomerAsync(string Mode, int CustomerCode)
        {
            using (var cnn = new SqlConnection(_connectionString))
            {
                try
                {
                    await cnn.OpenAsync();
                    using (var cmd = new SqlCommand("customerDetails", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@mode", Mode);
                        cmd.Parameters.AddWithValue("@CustomerCode", CustomerCode);

                        var errorIdParam = new SqlParameter("@Error_id", SqlDbType.VarChar, 50)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(errorIdParam);

                        await cmd.ExecuteNonQueryAsync();

                        string errorId = errorIdParam.Value?.ToString() ?? "Unknown";
                        return errorId;
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An error occurred while updating customer details.", ex);
                }
            }
        }

        public async Task<CustomerDto> GetCustomerByCodeAsync(string Mode, int CustomerCode)
        {
            CustomerDto customer = null;

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("customerDetails", con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Mode", Mode);
                    cmd.Parameters.AddWithValue("@CustomerCode", CustomerCode);

                    var errorIdParam = new SqlParameter("@Error_id", SqlDbType.VarChar, 10)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(errorIdParam);

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            customer = new CustomerDto
                            {
                                CustomerCode = Convert.ToInt32(reader["CustomerCode"]),
                                Name = reader["Name"].ToString(),
                                Address = reader["Address"].ToString(),
                                Email = reader["Email"].ToString(),
                                MobileNo = reader["MobileNo"].ToString(),
                                GeoLocation = reader["GeoLocation"].ToString()
                            };
                        }
                    }
                }
            }

            return customer;
        }


    }
}
