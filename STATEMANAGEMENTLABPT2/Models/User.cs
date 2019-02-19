using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace STATEMANAGEMENTLABPT2.Models
{
    public class User
    {
        [Required]
        [RegularExpression(@"^[a-zA-z]{2,}$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z]{2,}$")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[A-z0-9]{5,30}@[a-z]{5,10}.[a-z]{2,3}$")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z0-9]{5,}$")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}")]
        public string PhoneNumber { get; set; }

        public User(string firstName, string lastName, string email, string phoneNumber, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public User()
        {

        }
    }
}