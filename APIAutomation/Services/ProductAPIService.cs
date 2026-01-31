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

        // Cria variável para fazer chamadas GET, POST e desserialização JSON
        private readonly GET _apiGET;
        private readonly POST _apiPOST;
        private readonly PUT _apiPUT;
        private readonly JsonSerializerOptions _jsonOptions;

        // Construtor da classe ProductAPIService
        public ProductAPIService()
        {
            _apiGET = new GET();
            _apiPOST = new POST();
            _apiPUT = new PUT();

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        // Método para fazer uma requisição GET à API de produtos.
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
        // Método para fazer uma requisição POST à API de produtos.
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
        // Método para fazer uma requisição GET à API de marcas.
        public async Task<BrandListResponse> GetBrandListAsync(string url)
        {
            var response = await _apiGET.GetResponseAsync(url);
            
            var brandList = JsonSerializer.Deserialize<BrandListResponse>(response.Body, _jsonOptions);
            
            if (brandList == null)
            {
                throw new Exception("Desserialização falhou: brandList veio null.");
            }

            return brandList;
        }

        public async Task<APIMessageResponse> PutToProductAPIAsync(string url, string jsonBody = null)
        {
            
            var response = await _apiPUT.PutResponseAsync(url, jsonBody);
            
            var apiMessageResponse = JsonSerializer.Deserialize<APIMessageResponse>(response.Body, _jsonOptions);
            
            if (apiMessageResponse == null)
            {
                throw new Exception("Desserialização falhou: apiMessageResponse veio null.");
            }
            return apiMessageResponse;
        }
    }

}
