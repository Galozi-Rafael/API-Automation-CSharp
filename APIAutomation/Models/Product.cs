using System;
using System.Collections.Generic;
using System.Text;

namespace APIAutomation.Models
{
    // Classe que representa um produto na resposta da API
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Price { get; set; }

        public string Brand { get; set; }

        public CategoryProduct Category { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Name}, Preço: {Price}, Marca: {Brand}, Category: {Category}";
        }
    }
}
