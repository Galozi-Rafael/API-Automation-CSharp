using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace APIAutomation.Models
{
    // Classe que representa a resposta da lista de produtos da API
    internal class ProductListResponse
    {
        public int ResponseCode { get; set; }

        public List<Product> Products { get; set; }
    }
}
