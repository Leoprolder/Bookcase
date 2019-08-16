﻿using Bookcase.Models;
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
        //public ActionResult AddBook(Book book)
        public ActionResult AddBook(string Title, List<string> FirstName, List<string> LastName, int? PageCount, string Publisher, int? Year)
        {
            List<Author> authors = new List<Author>();
            int authorCount = FirstName.Count == LastName.Count ? FirstName.Count : 0;
            for (int i = 0; i < authorCount; i++)
            {
                authors.Add(new Author(FirstName[i], LastName[i]));
            }
            Book book = new Book(Title, authors, (int)PageCount, (int)Year, Publisher);
            db.Books.Add(book);
            db.SaveChanges();

            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;

            return View("Index");
        }

        [HttpPost]
        public ActionResult EditBook(int? Id, string Title, List<string> FirstName, List<string> LastName, int? PageCount, string Publisher, int? Year)
        {
            List<Author> authors = new List<Author>();
            int authorCount = FirstName.Count == LastName.Count ? FirstName.Count : 0;
            for (int i = 0; i < authorCount; i++)
            {
                authors.Add(new Author(FirstName[i], LastName[i]));
            }
            Book book = new Book(Title, authors, (int)PageCount, (int)Year, Publisher);
            book.Id = (int)Id;

            if (Id != null)
            {
                Book bookTemp = db.Books.Find((int)(Id));
                db.Books.Remove(bookTemp);
                db.SaveChanges();
            }

            db.Books.Add(book);
            db.SaveChanges();

            IEnumerable<Book> books = db.Books;
            ViewBag.Books = books;

            return View("Index");
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