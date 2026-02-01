using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomation.Models
{
    internal class CreateAccountRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Title { get; set; }          // Mr, Mrs, Miss
        public string BirthDate { get; set; }      // "01"
        public string BirthMonth { get; set; }     // "01"
        public string BirthYear { get; set; }      // "1990"

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string MobileNumber { get; set; }
    }
}
