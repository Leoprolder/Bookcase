﻿using Bookcase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            List<Book> books = new List<Book>(db.Books);

            string sorting = Request.Cookies["sorting"]?.Value ?? String.Empty;

            if(sorting.Equals("byName"))
            {
                TitleComparer titleComparer = new TitleComparer();
                books.Sort(titleComparer);
            }
            else if(sorting.Equals("byYear"))
            {
                YearComparer yearComparer = new YearComparer();
                books.Sort(yearComparer);
            }

            ViewBag.Books = books;

            return View();
        }

        [HttpPost]
        //public ActionResult AddBook(Book book)
        public ActionResult AddBook(string Title, List<string> FirstName, List<string> LastName, int? PageCount, string Publisher, int? Year)
        {
            try
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
            }
            catch(Exception ex)
            {
                ViewBag.ValidationError = ex.Message;
            }

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
            Book newBook = new Book(Title, authors, (int)PageCount, (int)Year, Publisher);

            Book book = db.Books.Find(Id);
            book.Title = newBook.Title;
            book.Authors = newBook.Authors;
            book.Publisher = newBook.Publisher;
            book.PageCount = (int)newBook.PageCount;
            book.Year = (int)newBook.Year;
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
    }
}