using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookManagementwithAdo
{
    public class AddressRepo
    {

        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AddressBookUsingAdo;Integrated Security=True"; //Specifying the connection string from the sql server connection.

        SqlConnection connection = new SqlConnection(connectionString);

        public void DataBaseConnection()
        {
            try
            {
                DateTime now = DateTime.Now;
                connection.Open();
                using (connection)
                {
                    Console.WriteLine($"Connection is created Successful {now}");

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void GetAllContact()
        {

            AddressBookModel model = new AddressBookModel();
            try
            {
                using (this.connection)
                {
                    string query = @"select * from AddressBookTables"; 

                    SqlCommand command = new SqlCommand(query, this.connection); 

                    connection.Open();  

                    SqlDataReader reader = command.ExecuteReader(); 
                    if (reader.HasRows)
                    {

                        while (reader.Read()) 
                        {
                            model.FirstName = reader.GetString(0);
                            model.LastName = reader.GetString(1);
                            model.Address = reader.GetString(2);
                            model.City = reader.GetString(3);
                            model.State = reader.GetString(4);
                            model.ZipCode = reader.GetString(5);
                            model.PhoneNumber = reader.GetString(6);
                            model.Email = reader.GetString(7);
                           
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", model.FirstName, model.LastName,
                                model.Address, model.City, model.State, model.ZipCode, model.PhoneNumber, model.Email);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Recors Found Address Book System Table");
                    }
                    reader.Close();
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                connection.Close(); 
            }

        }
        public bool AddDataToTable(AddressBookModel model)
        {
            try
            {
                using (connection) 
                {
                    SqlCommand command = new SqlCommand("[dbo].[AddressBookSystemProcedure]", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", model.FirstName);
                    command.Parameters.AddWithValue("@LastName", model.LastName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@State", model.State);
                    command.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", model.Email);
                  

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)   
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public bool EditContactUsingName(string ZipCode, string FirstName, string LastName)
        {

            try
            {
                using (this.connection)
                {
                    connection.Open();
                    string query = @"update AddressBookTables set ZipCode = @parameter1
                    where FirstName = @parameter2 and LastName = @parameter3";

                    SqlCommand command = new SqlCommand(query, this.connection);
                    command.Parameters.AddWithValue("@parameter1", ZipCode);
                    command.Parameters.AddWithValue("@parameter2", FirstName);
                    command.Parameters.AddWithValue("@parameter3", LastName);

                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
        public bool DeleteContactUsingName(string FirstName, string LastName)
        {
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = "delete from AddressBookTables where FirstName = @parameter1 and LastName =@parameter2";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@parameter1", FirstName);
                    command.Parameters.AddWithValue("@parameter2", LastName);

                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}