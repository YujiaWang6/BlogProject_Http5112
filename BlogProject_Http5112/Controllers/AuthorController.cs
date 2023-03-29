using System;
using System.Collections.Generic;
using System.Diagnostics;
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


        // GET: /Author/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            AuthorDataController controller = new AuthorDataController();
            Author NewAuthor = controller.FindAuthor(id);

            return View(NewAuthor);
        }


        // POST: /Author/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            AuthorDataController controller = new AuthorDataController();
            controller.DeleteAuthor(id);
            return RedirectToAction("List");
        }

        //GET: /Author/New
        public ActionResult New()
        {
            return View();
        }

        //POST: /Author/Create
        [HttpPost]
        public ActionResult Create(string AuthorFname, string AuthorLname, string AuthorBio, string AuthorEmail)
        {
            //identify that this method is running
            //identify the inputs provided from the form

            Debug.WriteLine("I have accessed the Create Method!");
            Debug.WriteLine(AuthorFname);

            Author NewAuthor = new Author();
            NewAuthor.AuthorFname = AuthorFname;
            NewAuthor.AuthorLname = AuthorLname;
            NewAuthor.AuthorBio = AuthorBio;
            NewAuthor.AuthorEmail = AuthorEmail;

            AuthorDataController controller = new AuthorDataController();
            controller.AddAuthor(NewAuthor);

            return RedirectToAction("List");
        }

    }
}