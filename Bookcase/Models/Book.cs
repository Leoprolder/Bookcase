using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookcase.Models
{
    public class Book
    {
        public int Id { get; set; }
        //[Display(Name = "Название")]
        //[Required()]
        public string Title { get; set; }
        //[Display(Name = "Авторы")]
        //[Required()]
        public List<Author> Authors { get; set; }
        //[Display(Name = "Число страниц")]
        //[Required()]
        public int PageCount { get; set; }
        //[Display(Name = "Издатель")]
        public string Publisher { get; set; }
        //[Display(Name = "Год издания")]
        //[Required()]
        public int Year { get; set; }

        public Book()
        {

        }

        public Book(string title, List<Author> authors, int pageCount, int year, string publisher = "")
        {
            Title = title;
            Authors = authors;
            PageCount = pageCount;
            Year = year;
            Publisher = publisher;
        }
    }
}