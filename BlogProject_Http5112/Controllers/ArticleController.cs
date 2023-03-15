using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject_Http5112.Models;

namespace BlogProject_Http5112.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return View();
        }


        //GET: /Article/List
        public ActionResult List()
        {
            ArticleDataController controller = new ArticleDataController();
            IEnumerable<Article> Articles= controller.ListArticles();

            return View(Articles);
        }

        public ActionResult Show(int id)
        {
            ArticleDataController controller = new ArticleDataController();
            Article NewArticle = controller.DetailArticles(id);

            return View(NewArticle);
        }
    }
}