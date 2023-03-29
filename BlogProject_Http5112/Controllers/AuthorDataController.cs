using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BlogProject_Http5112.Models;
using MySql.Data.MySqlClient;

namespace BlogProject_Http5112.Controllers
{

    public class AuthorDataController : ApiController
    {
        //The database context class which allows us to access our MySQL Database/

        private BlogDbContext Blog = new BlogDbContext();

        //This Controller will access the authors table of our blog database.
        /// <summary>
        /// Return a list of Authors in the system
        /// </summary>
        /// <example>GET api/AuthorData/ListAuthors</example>
        /// <returns>
        /// A list of authors(first names and last names)
        /// </returns>
        
        [HttpGet]
        [Route("api/AuthorData/ListAuthors/{searchKey?}")]  
        public IEnumerable<Author> ListAuthors(string searchKey=null)
        {
            //create an instance of a connection
            MySqlConnection Conn = Blog.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "select * from Authors where lower(authorfname) like lower(@key) or lower(authorlname) like lower(@key) or lower(concat (authorfname, ' ', authorlname)) like lower(@key)";

            cmd.Parameters.AddWithValue("key", "%" + searchKey + "%");
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Author
            List<Author> Authors = new List<Author> {};

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int AuthorId = (int)ResultSet["authorid"];
                string AuthorFname = (string)ResultSet["authorfname"];
                string AuthorLName = (string)ResultSet["authorlname"];
                string AuthorBio = (string)ResultSet["authorbio"];
                DateTime AuthorJoinDate = (DateTime)ResultSet["authorjoindate"];

                Author NewAuthor = new Author();
                NewAuthor.Authorid = AuthorId; 
                NewAuthor.AuthorFname = AuthorFname;
                NewAuthor.AuthorLname = AuthorLName;
                NewAuthor.AuthorBio = AuthorBio;
                NewAuthor.AuthorJoinDate = AuthorJoinDate;


                //add the author name to the list
                Authors.Add(NewAuthor);
            }

            //close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of author names
            return Authors;
            

        }


        [HttpGet]
        public Author FindAuthor(int id)
        {
            Author NewAuthor = new Author();

            //create an instance of a connection
            MySqlConnection Conn = Blog.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "select * from Authors where authorid = " + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int AuthorId = (int)ResultSet["authorid"];
                string AuthorFname = (string)ResultSet["authorfname"];
                string AuthorLName = (string)ResultSet["authorlname"];
                string AuthorBio = (string)ResultSet["authorbio"];
                DateTime AuthorJoinDate = (DateTime)ResultSet["authorjoindate"];


                NewAuthor.Authorid = AuthorId;
                NewAuthor.AuthorFname = AuthorFname;
                NewAuthor.AuthorLname = AuthorLName;
                NewAuthor.AuthorBio = AuthorBio;
                NewAuthor.AuthorJoinDate = AuthorJoinDate;
            }

            Conn.Close();

            return NewAuthor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <example>POST : /api/AuthorData/DeleteAuthor/3</example>
        [HttpPost]
        public void DeleteAuthor(int id)
        {

            MySqlConnection Conn = Blog.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Delete from authors where authorid=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();

        }


        [HttpPost]
        public void AddAuthor([FromBody]Author NewAuthor)
        {
            MySqlConnection Conn = Blog.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Insert into authors (authorfname, authorlname, authorbio, authorjoindate, authoremail) VALUES(@AuthorFname,@AuthorLname,@AuthorBio, CURRENT_DATE(),@AuthorEmail)";
            cmd.Parameters.AddWithValue("@AuthorFname", NewAuthor.AuthorFname);
            cmd.Parameters.AddWithValue("@AuthorLname", NewAuthor.AuthorLname);
            cmd.Parameters.AddWithValue("@AuthorBio", NewAuthor.AuthorBio);
            cmd.Parameters.AddWithValue("@AuthorEmail", NewAuthor.AuthorEmail);

            cmd.Prepare();

            cmd.ExecuteNonQuery();

            Conn.Close();


        }

    }
}
