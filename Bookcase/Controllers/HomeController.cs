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
            //IEnumerable<Book> books = db.Books;
            //ViewBag.Books = books;

            Author tolstoy = new Author("Лев", "Толстой");
            Author another = new Author("Аноним", "Анонимов");
            List<Author> authors = new List<Author>();
            authors.Add(tolstoy);
            authors.Add(another);

            Book book = new Book("Война и мир", authors, 555, 1750);
            List<Book> books = new List<Book>();
            books.Add(book);
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

        [HttpDelete]
        public ActionResult DeleteBook(int bookId)
        {
            db.Books.Remove(db.Books.Find(bookId));

            return View();
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