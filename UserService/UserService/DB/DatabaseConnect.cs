using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserService.Interfaces;

namespace UserService.DB {
    public class DatabaseConnect:IDatabase {
        // String variable to hold the connection string for the database.
        private static readonly string connectString;

        static DatabaseConnect() {
            connectString = "Server=localhost;Database=Art-Zvit;Trusted_Connection=True;TrustServerCertificate=True;";
        }
        public  SqlConnection OpenConnection() {
            var connection = new SqlConnection(connectString);
            connection.Open();
            return connection;
        }

    
    }
}