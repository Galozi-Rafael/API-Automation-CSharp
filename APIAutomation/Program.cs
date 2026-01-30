// Programa destinado a testar serviços de API RESTful utilizando chamadas HTTP GET.
// Ele vai interagir com as funcionalida API do site "https://automationexercise.com/api/"
using APIAutomation.APIServices;
using APIAutomation.Models;
using APIAutomation.Services;
using System;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Text.Json;


class Program
{
    static async Task Main(string[] args)
    {
        #region Exercício 1 - Requisição GET
        string productUrl = "https://automationexercise.com/api/productsList";
        // Cria uma instância do serviço de API de produtos.
        ProductAPIService productAPIService = new ProductAPIService();
        // Chama o método para obter a lista de produtosjá desserializada.
        ProductListResponse productList = await productAPIService.GetProductListAsync(productUrl);

        // Exibe o código de resposta e a contagem de produtos.
        Console.WriteLine("--- Resultado da Requisição GET ---");
        Console.WriteLine($"O código retornado foi: {productList.ResponseCode}.");
        Console.WriteLine($"Foram encontrados {productList.Products.Count} produtos na lista.");

        // Exibe os detalhes de cada produto.
        foreach (var product in productList.Products)
        {
            Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Brand: {product.Brand}, Category: {product.Category.Usertype}, {product.Category.Category}");
        }
        #endregion

        #region Exercício 2 - Requisição POST e teste negativo
        // Chama o método para fazer uma requisição POST.
        
        APIMessageResponse postResponse = await productAPIService.PostToProductAPIAsync(productUrl);

        // Exibe o código de resposta e a mensagem retornada.
        Console.WriteLine("\n--- Resultado da Requisição POST ---");
        Console.WriteLine($"ResponseCode do JSON: {postResponse.ResponseCode}");
        Console.WriteLine($"Response Body do POST: {postResponse.Message}");
        #endregion

        #region Exercício 3 - BrandList GET
        string brandListUrl = "https://automationexercise.com/api/brandsList";
        // Chama o método para obter a lista de marcas.
        BrandListResponse brandList = await productAPIService.GetBrandListAsync(brandListUrl);

        // Exibe o código de resposta e a contagem de marcas.
        Console.WriteLine("\n--- Resultado da Requisição GET - BrandList ---");
        foreach (var brand in brandList.Brands)
        {
            Console.WriteLine($"Brand ID: {brand.ID}, Brand: {brand.Brand}");
        }
        #endregion

    }
}
       