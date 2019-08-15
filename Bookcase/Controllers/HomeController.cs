using Bookcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookcase.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;

            return View();
        }

        [HttpPost]
        public ActionResult AddBook(Book book)
        {
            db.Books.Add(book);
            ViewBag.Books = db.Books;

            return View();
        }

        [HttpPut]
        public ActionResult EditBook(Book newBook)
        {
            Book book = db.Books.Find(newBook.Id);
            //?

            return View();
        }

        [HttpGet]
        public ActionResult DeleteBook(int? Id)
        {
            if (Id != null)
            {
                Book book = db.Books.Find((int)(Id));
                db.Books.Remove(book);
                db.SaveChanges();
            }

            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;

            return View("Index");
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}