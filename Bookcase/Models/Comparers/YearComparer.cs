using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookcase.Models
{
    public class YearComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (x.Year > y.Year)
                return 1;
            else if (x.Year < y.Year)
                return -1;

            return 0;
        }
    }
}