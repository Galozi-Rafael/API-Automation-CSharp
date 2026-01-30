using APIAutomation.Models;
using APIAutomation.APIServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIAutomation.Services
{
    internal class ProductAPIService
    {
        // Cria variável para fazer chamadas GET e desserialização JSON
        private readonly GET _apiGET;
        private readonly JsonSerializerOptions _jsonOptions;

        // Construtor da classe ProductAPIService
        public ProductAPIService()
        {
            _apiGET = new GET();
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        // Método para obter a lista de produtos
        public async Task<ProductListResponse> GetProductListAsync(string url)
        {
            var response = await _apiGET.GetResponseAsync(url);

            if (response.StatusCode != 200)
            {
                throw new Exception($"Failed to fetch product list. Status code: {response.StatusCode}");
            }

            var productList = JsonSerializer.Deserialize<ProductListResponse>(response.Body, _jsonOptions);

            if (productList == null)
            {
                throw new Exception("Desserialização falhou: productList veio null.");
            }

            return productList;
        }
    }
}
