﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//install MySQL.Data
//via Tools - NuGet package manager - manage nuget packages for solution
//"Browse" tab
//search for mysql.data and install to project
using MySql.Data.MySqlClient;

namespace BlogProject_Http5112.Models
{

    public class BlogDbContext
    {
        //These are readonly "secret" properties
        //only the BlogDbContext class can use them
        //change these to match your own local blog database!

        private static string User { get { return "root"; } }
        
        private static string Password { get { return "root"; } }

        private static string Database { get { return "blog"; } }

        private static string Server { get { return "localhost"; } }

        private static string Port { get { return "3306"; } }

        //ConnectionString is a series of credentials used to connect to the database.

        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }


        //This is the method we actually use to get the database!
        /// <summary>
        /// Returns a connection to the blog database.
        /// </summary>
        /// <example>
        /// Private BlogDbContext Blog = new BlogDbContext();
        /// MySqlConnection Conn = Blog.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        
        public MySqlConnection AccessDatabase()
        {
            //We are instantiating the MySqlConnection Class to create an object
            //the object is a specific connection to our blog database on port 3306 of localhost
            return new MySqlConnection(ConnectionString);
        }


    }
}