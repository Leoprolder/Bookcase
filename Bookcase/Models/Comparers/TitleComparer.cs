using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookcase.Models
{
    public class TitleComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return String.Compare(x.Title, y.Title);
        }
    }
}