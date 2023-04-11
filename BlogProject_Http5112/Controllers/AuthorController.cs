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
            Author SelectAuthor = controller.FindAuthor(id);
    
            return View(SelectAuthor);
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

        //GET: /Author/Update/{id}
        /// <summary>
        /// Routes to a dynamically generated "Author Update" Page. Gathers information from the database.
        /// </summary>
        /// <param name="id">ID of the Author</param>
        /// <returns>A dynamic "Update Author" webpage which provides the current information of the author and asks the user for new information as part of a form.</returns>
        /// <example>GET: /Author/Update/{id}</example>
        public ActionResult Update(int id)
        {
            AuthorDataController controller = new AuthorDataController();
            Author SelectedAuthor = controller.FindAuthor(id);
            return View(SelectedAuthor);
        }

        /// <summary>
        /// Receives a POST request containing information about an existing author in the system with new values. 
        /// Conveys this inFormation to the API, and redirects to the "Author Show" page of our updated author.
        /// </summary>
        /// <param name="id">ID of the Author to update</param>
        /// <param name="AuthorFname">The updated first name of the author</param>
        /// <param name="AuthorLname">The updated last name of the author</param>
        /// <param name="AuthorBio">The updated bio of the author</param>
        /// <param name="AuthorEmail">The updated email of the author</param>
        /// <returns>A dynamic webpage with provides the current information of the author.</returns>
        /// <example>POST: /Author/Update/{id}</example>
        //POST: /Author/Update/{id}
        [HttpPost]
        public ActionResult Update(int id, string AuthorFname, string AuthorLname, string AuthorBio, string AuthorEmail)
        {

            Author AuthorInfo = new Author();
            AuthorInfo.AuthorFname = AuthorFname;
            AuthorInfo.AuthorLname = AuthorLname;
            AuthorInfo.AuthorBio = AuthorBio;
            AuthorInfo.AuthorEmail = AuthorEmail;

            AuthorDataController controller = new AuthorDataController();
            controller.UpdateAuthor(id, AuthorInfo);


            return RedirectToAction("Show/" + id);
        }
    }
}