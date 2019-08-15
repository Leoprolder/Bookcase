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
            for (int i = 0; i < 20; i++)
            {
                Author tolstoy = new Author("Лев", "Толстой");
                Author another = new Author("Аноним", "Анонимович");
                List<Author> authors = new List<Author>();
                authors.Add(tolstoy);
                authors.Add(another);

                Book book = new Book("Война и мир", authors, 555, 1750);
                db.Books.Add(book);

                Author gayNigga = new Author("Гей", "Ниггер");
                Author fromSpace = new Author("Из", "Космоса");
                List<Author> gayNiggaFromSpace = new List<Author>();
                gayNiggaFromSpace.Add(gayNigga);
                gayNiggaFromSpace.Add(fromSpace);

                Book book2 = new Book("Геи ниггеры из далёкого космоса", gayNiggaFromSpace, 10, 2077);
                db.Books.Add(book2);
            }

            base.Seed(db); 
        }
    }
}