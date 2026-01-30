using APIAutomation.APIServices;
using System;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


class Program
{
    static async Task Main(string[] args)
    {
        // Cria uma instância da classe GET
        GET apiGET = new GET();

        string url = "https://automationexercise.com/api/productsList";

        // Chama o método GetResponseAsync para obter a resposta da URL fornecida
        var response = await apiGET.GetResponseAsync(url);

        Console.WriteLine($"O código retornado foi: {response.StatusCode}.");
        Console.WriteLine(response.Body);
    }
}
       