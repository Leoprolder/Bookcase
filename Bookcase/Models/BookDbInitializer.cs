using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bookcase.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            //Author tolstoy = new Author("Лев", "Толстой");
            //List<Author> authors = new List<Author>();
            //authors.Add(tolstoy);

            //Book book = new Book("Война и мир", authors, 555, 1750);
            //context.Books.Add(book);

            //context.Books.Add(new Book
            //{
            //    Title = "Война и мир",
            //    PageCount = 555,
            //    Publisher = "Москва",
            //    Year = 1750,
            //    Authors = {
            //        new Author
            //        {
            //            FirstName = "Лев",
            //            LastName = "Толстой"
            //        }
            //    }
            //});

            base.Seed(context); 
        }
    }
}