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
        private string firstName;
        [Display(Name = "Имя")]
        [Required()]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length <= 20)
                    firstName = value;
                else
                    throw new Exception("Длина имени автора не может быть длиннее 20 символов");
            }
        }
        private string lastName;
        [Display(Name = "Фамилия")]
        [Required()]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value.Length <= 20)
                    lastName = value;
                else
                    throw new Exception("Длина фамилии автора не может быть длиннее 20 символов");
            }
        }

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