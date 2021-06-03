using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookMultiThreading
{
    public class AddressBookRepository
    {
        public static SqlConnection connection { get; set; }
       
        public void RetrieveAllContactDetails()
        {
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            AddressBookModel model = new AddressBookModel();
            try
            {
                using (connection)
                {
                    string query = @"select * from dbo.Address_Book";
                    SqlCommand command = new SqlCommand(query, connection);
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
                            model.Zip = reader.GetInt32(5);
                            model.PhoneNumber = reader.GetInt64(6);
                            model.EmailId = reader.GetString(7);
                            model.AddressBookType = reader.GetString(8);
                            model.AddressBookName = reader.GetString(9);
                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", model.FirstName, model.LastName,
                                model.Address, model.City, model.State, model.Zip, model.PhoneNumber, model.EmailId, model.AddressBookType, model.AddressBookName);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
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

        
        public bool UpdateExistingContactUsingByName(string FirstName, string LastName, string EmailId)
        {
            DBConnection dbc = new DBConnection();
            connection = dbc.GetConnection();
            try
            {
                using (connection)
                {
                    connection.Open();
                    string query = @"update dbo.Address_Book set Email = @parameter1
                    where FirstName = @parameter2 and LastName = @parameter3";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@parameter1", EmailId);
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
                connection.Close();
            }
        }
    }
}
