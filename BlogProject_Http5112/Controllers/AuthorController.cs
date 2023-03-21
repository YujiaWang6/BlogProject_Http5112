using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogProject_Http5112.Models;

namespace BlogProject_Http5112.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }


        // GET: /Author/List
        public ActionResult List(string searchKey = null)
        {

            AuthorDataController controller = new AuthorDataController();
            IEnumerable<Author> Authors = controller.ListAuthors(searchKey);
            return View(Authors);
        }


        // GET: /Author/Show/{id}
        public ActionResult Show(int id)
        {
            AuthorDataController controller = new AuthorDataController();
            Author NewAuthor = controller.FindAuthor(id);
    
            return View(NewAuthor);
        }
    }
}