using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject_Http5112.Models
{
    public class Author
    {
        //The following fields define an Author
        //properties meant for object, fields meant for class
        public int Authorid;
        public string AuthorFname;
        public string AuthorLname;
        public string AuthorBio;
        public string AuthorEmail;
        public DateTime AuthorJoinDate;

        //parameter-less constructor function
        public Author()
        {

        }
    }
}