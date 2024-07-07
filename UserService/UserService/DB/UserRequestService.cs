using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using UserService.DTO;
using UserService.Interfaces;

namespace UserService.DB {
    public class UserRequestService : IUserRequest {

        public bool CreateUser(IDatabase database, IUser user) {
            string selectQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email OR TIN = @TIN;";
            string insertQuery = "INSERT INTO Users(FullName, TIN, Email, ContactPhone, CreationDate, LastModifiedDate) " +
                                 "VALUES(@FullName, @TIN, @Email, @ContactPhone, @CreationDate, @LastModifiedDate);";

            try
            {
                using (var connection = database.OpenConnection())
                {
                    // Check if the user already exists based on Email or TIN
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Email", user.Email);
                        selectCommand.Parameters.AddWithValue("@TIN", user.TIN);

                        int existingCount = (int)selectCommand.ExecuteScalar();
                        if (existingCount > 0)
                        {
                            // User with the same Email or TIN already exists, do not insert
                            return false;
                        }
                    }

                    // Insert the new user if not already existing
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@FullName", user.FullName);
                        insertCommand.Parameters.AddWithValue("@TIN", user.TIN);
                        insertCommand.Parameters.AddWithValue("@Email", user.Email);
                        insertCommand.Parameters.AddWithValue("@ContactPhone", user.ContactPhone);
                        insertCommand.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                        insertCommand.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if insertion was successful
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message); // Log any exceptions
                return false;
            }
        }

        private void LogError(string message) {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFile.txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{DateTime.Now}: {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error logging the error: " + ex.Message);
            }
        }
        public string TestingDB(IDatabase database) {
            string result="good";
            string sqlQuery = "SELECT * FROM Users WHERE ID=1;";
            try
            {
                using (var connection = database.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) {
                                 return result = "Bad";
                            }
                        }
                        }
                    }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                return ex.Message.ToString();
            }
            return result;
        }

        public bool DeleteUsers(IDatabase database, int id) {
            string sqlQuery = "DELETE FROM Users WHERE ID = @ID;";
            try
            {
                using (var connection = database.OpenConnection())
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
            return false;
        }

        public bool UpdateUsers(IDatabase database, IUser user) {
            string selectQuery = "SELECT COUNT(*) FROM Users WHERE (Email = @Email OR TIN = @TIN) AND ID != @ID;";
            string updateQuery = "UPDATE Users SET " +
                                 "FullName = @FullName, " +
                                 "TIN = @TIN, " +
                                 "Email = @Email, " +
                                 "ContactPhone = @ContactPhone, " +
                                 "LastModifiedDate = @LastModifiedDate " +
                                 "WHERE ID = @ID;";
            try
            {
                using (var connection = database.OpenConnection())
                {
                    // Check if there are other users with the same Email or TIN, excluding the current user
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                    {
                        selectCommand.Parameters.AddWithValue("@Email", user.Email);
                        selectCommand.Parameters.AddWithValue("@TIN", user.TIN);
                        selectCommand.Parameters.AddWithValue("@ID", user.ID);

                        int existingCount = (int)selectCommand.ExecuteScalar();
                        if (existingCount > 0)
                        {
                            // Other users with the same Email or TIN found, cannot update
                            return false;
                        }
                    }

                    // Update the user if no other users with the same Email or TIN
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@ID", user.ID);
                        updateCommand.Parameters.AddWithValue("@FullName", user.FullName);
                        updateCommand.Parameters.AddWithValue("@TIN", user.TIN);
                        updateCommand.Parameters.AddWithValue("@Email", user.Email);
                        updateCommand.Parameters.AddWithValue("@ContactPhone", user.ContactPhone);
                        updateCommand.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);

                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        return rowsAffected > 0; // Return true if update was successful
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message); // Log any exceptions
                return false;
            }
        }



        public List<User>  ReadUsers(IDatabase database) {
            string sqlQuery = "SELECT * FROM Users;";
            List<User> users = new List<User>();
            try
            {
                using (var connection = database.OpenConnection())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = sqlQuery;
                        using (SqlDataReader reader = command.ExecuteReader()){
                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    ID = reader.GetInt32(0),
                                    FullName = reader.GetString(1),
                                    TIN = reader.GetString(2),
                                    Email = reader.GetString(3),
                                    ContactPhone = reader.GetString(4),
                                    CreationDate = reader.GetDateTime(5),
                                    LastModifiedDate = reader.GetDateTime(6)
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
                return users;
                }
            catch (Exception ex){
                LogError(ex.Message);
            }
            return users;
            }
        }
    }
