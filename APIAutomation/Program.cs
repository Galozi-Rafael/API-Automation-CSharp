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
        string url = "https://automationexercise.com/api/productsList";

        // Cria uma instância do serviço de API de produtos.
        ProductAPIService productAPIService = new ProductAPIService();
        // Chama o método para obter a lista de produtosjá desserializada.
        ProductListResponse productList = await productAPIService.GetProductListAsync(url);

        Console.WriteLine($"O código retornado foi: {productList.ResponseCode}.");

        Console.WriteLine($"Foram encontrados {productList.Products.Count} produtos na lista.");

        // Exibe os detalhes de cada produto.
        foreach (var product in productList.Products)
        {
            Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Brand: {product.Brand}, Category: {product.Category.Usertype}, {product.Category.Category}");
        }

        POST apiPOST = new POST();

        var postResponse = await apiPOST.PostResponseAsync(url);

        var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        
        APIMessageResponse apiMessageResponse = JsonSerializer.Deserialize<APIMessageResponse>(postResponse.Body, option);
        Console.WriteLine($"POST request returned HTTP status code: {postResponse.StatusCode}");
        Console.WriteLine($"Response Body do POST desserializado: {postResponse.Body}");
        Console.WriteLine($"ResponseCode do JSON: {apiMessageResponse.ResponseCode}");
        Console.WriteLine($"Response Body do POST: {apiMessageResponse.Message}");



    }
}
       