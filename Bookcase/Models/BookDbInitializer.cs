using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bookcase.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {            
            Author Dostoevskiy = new Author("Фёдор", "Достоевский");
            List<Author> authors = new List<Author>();
            authors.Add(Dostoevskiy);

            Book book = new Book("Идиот", authors, 813, 1869);
            db.Books.Add(book);

            Author Pushkin = new Author("Александр", "Пушкин");
            List<Author> authors2 = new List<Author>();
            authors2.Add(Pushkin);

            Book book2 = new Book("Капитанская дочка", authors2, 142, 1836, "Библиотека Огонёк");
            db.Books.Add(book2);

            base.Seed(db); 
        }
    }
}