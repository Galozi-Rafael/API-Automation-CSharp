using APIAutomation.APIServices;
using APIAutomation.Models;
using System;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using System.Text.Json;


class Program
{
    static async Task Main(string[] args)
    {
        // Cria uma instância da classe GET
        GET apiGET = new GET();

        string url = "https://automationexercise.com/api/productsList";

        // Chama o método GetResponseAsync para obter a resposta da URL fornecida
        var response = await apiGET.GetResponseAsync(url);

        //Console.WriteLine($"O código retornado foi: {response.StatusCode}.");
        //Console.WriteLine(response.Body);

        var option = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        ProductListResponse productList = JsonSerializer.Deserialize<ProductListResponse>(response.Body, option);

        Console.WriteLine($"O código retornado foi: {productList.ResponseCode}.");

        Console.WriteLine($"Foram encontrados {productList.Products.Count} produtos na lista.");

        Console.WriteLine(productList.Products[0]);
    }
}
       