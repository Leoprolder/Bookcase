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
        private string title;
        [Display(Name = "Название")]
        [Required()]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value.Length <= 30)
                    title = value;
                else
                    throw new Exception("Слишком длинное название книги");
            }
        }
        [Display(Name = "Авторы")]
        [Required()]
        public string Authors { get; private set; }
        private int pageCount;
        [Display(Name = "Число страниц")]
        [Required()]
        public int PageCount
        {
            get
            {
                return pageCount;
            }
            set
            {
                if (value > 0 && value < 10000)
                    pageCount = value;
                else
                    throw new Exception("Число страниц не может быть меньше 1 и больше 10000");
            }

        }
        private string publisher;
        [Display(Name = "Издатель")]
        public string Publisher
        {
            get
            {
                return publisher;
            }
            set
            {
                if (value.Length <= 30)
                    publisher = value;
                else
                    throw new Exception("Имя издательства не может быть длиной больше 30 символов");
            }
        }
        private int year;
        [Display(Name = "Год издания")]
        [Required()]
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value >= 1800)
                    year = value;
                else
                    throw new Exception("Год издания книги не может быть раньше 1800");
            }
        }

        public Book()
        {

        }

        public Book(string title, List<Author> authors, int pageCount, int year, string publisher = "")
        {
            Title = title;
            PageCount = pageCount;
            Year = year;
            Publisher = publisher;

            if (authors.Count < 1)
                throw new Exception("У книги должен быть хотя бы один автор");

            for (int i = 0; i < authors.Count; i++)
            {
                string authorName = $"{authors[i].FirstName} {authors[i].LastName}";
                if (authorName == " ")
                    continue;
                Authors += authorName;
                if (i != authors.Count - 1)
                    Authors += ", ";
            }
        }
    }
}