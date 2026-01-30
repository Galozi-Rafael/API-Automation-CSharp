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
        private readonly POST _apiPOST;
        private readonly JsonSerializerOptions _jsonOptions;

        // Construtor da classe ProductAPIService
        public ProductAPIService()
        {
            _apiGET = new GET();
            _apiPOST = new POST();

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
        
        public async Task<APIMessageResponse> PostToProductAPIAsync(string url, string jsonBody = null)
        {
            var response = await _apiPOST.PostResponseAsync(url, jsonBody);
            
            var apiMessageResponse = JsonSerializer.Deserialize<APIMessageResponse>(response.Body, _jsonOptions);
            
            if (apiMessageResponse == null)
            {
                throw new Exception("Desserialização falhou: apiMessageResponse veio null.");
            }
            return apiMessageResponse;
        }
    }

}
