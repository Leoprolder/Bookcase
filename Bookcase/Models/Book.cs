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
        public string Authors { get; set; }
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
            PageCount = pageCount;
            Year = year;
            Publisher = publisher;

            for (int i = 0; i < authors.Count; i++)
            {
                Authors += $"{authors[i].FirstName} {authors[i].LastName}";
                if (i != authors.Count - 1)
                    Authors += ", ";
            }
        }
    }
}