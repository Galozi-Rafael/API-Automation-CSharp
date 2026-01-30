using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace APIAutomation.Models
{
    // Classe que representa a categoria no objeto Product
    internal class CategoryProduct
    {
        public UserType Usertype { get; set; }

        public string Category { get; set; }

        public override string ToString()
        {
            return $"Usertype: {Usertype}, Category: {Category}";
        }

    }
}
