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
    //GET api/ArticleData/ListArticles
    public class ArticleDataController : ApiController
    {

        private BlogDbContext Blog = new BlogDbContext();

        [HttpGet]
        public IEnumerable<Article> ListArticles()
        {
            MySqlConnection Conn = Blog.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from Articles";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Article> Articles = new List<Article> { };


            while (ResultSet.Read())
            {


                string ArticleName = (string)ResultSet["articletitle"];
                string ArticleBody = (string)ResultSet["articlebody"];
                int ArticleId = (int)ResultSet["articleid"];


                Article NewArticle = new Article();
                NewArticle.ArticleTitle = ArticleName;
                NewArticle.ArticleBody = ArticleBody;
                NewArticle.ArticleId = ArticleId;

                Articles.Add(NewArticle);
            }

            Conn.Close();
            return Articles;
        }

        [HttpGet]
        public Article DetailArticles(int id)
        {
            Article NewArticle = new Article();

            MySqlConnection Conn = Blog.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from Articles";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                string ArticleName = (string)ResultSet["articletitle"];
                string ArticleBody = (string)ResultSet["articlebody"];
                int ArticleId = (int)ResultSet["articleid"];


                NewArticle.ArticleTitle = ArticleName;
                NewArticle.ArticleBody = ArticleBody;
                NewArticle.ArticleId = ArticleId;
            }
            return NewArticle;
        }
    }
}
