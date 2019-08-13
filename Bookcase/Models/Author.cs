using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bookcase.Models
{
    public class Author
    {
        public int Id { get; set; }
        //[Display(Name = "Имя")]
        //[Required()]
        public string FirstName { get; set; }
        //[Display(Name = "Фамилия")]
        //[Required()]
        public string LastName { get; set; }

        public Author()
        {

        }

        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}