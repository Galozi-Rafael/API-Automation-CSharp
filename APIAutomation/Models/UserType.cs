using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace APIAutomation.Models
{
    // Classe que representa a categoria usertype no objeto Category
    internal class UserType
    {
        public string Usertype { get; set; }

        public override string ToString()
        {
            return $"Usertype: {Usertype}";
        }
    }
}
