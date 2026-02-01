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
        Console.WriteLine($"Foram encontradas: {brandList.Brands.Count} marcas.");
        foreach (var brand in brandList.Brands)
        {
            Console.WriteLine($"Brand ID: {brand.ID}, Brand: {brand.Brand}");
        }
        #endregion

        #region Exercício 4 - Requisição PUT e teste negativo
        // Chama o método para fazer uma requisição PUT.
        APIMessageResponse putResponse = await productAPIService.PutToProductAPIAsync(productUrl);
        // Exibe o código de resposta e a mensagem retornada.
        Console.WriteLine("\n--- Resultado da Requisição PUT ---");
        Console.WriteLine($"ResponseCode do JSON: {putResponse.ResponseCode}");
        Console.WriteLine($"Response Body do PUT: {putResponse.Message}");
        #endregion

        #region Exercício 5 - POST com Formulário
        string searchUrl = "https://automationexercise.com/api/searchProduct";
        string searchTerm = "top";
        var formData = new Dictionary<string, string>
        {
            { "search_product", searchTerm }
        };
        // Chama o método para fazer uma requisição POST com dados de formulário.
        ProductListResponse postSearchResponse = await productAPIService.SearchProductAPIAsync(searchUrl, formData);

        // Exibe o código de resposta e a mensagem retornada.
        Console.WriteLine("\n--- Resultado da Requisição POST com Formulário ---");
        Console.WriteLine($"ResponseCode do JSON: {postSearchResponse.ResponseCode}");
        Console.WriteLine($"Quantidade de produtos encontrados: {postSearchResponse.Products.Count}");

        foreach (var product in postSearchResponse.Products)
        {
            Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}, Brand: {product.Brand}, Category: {product.Category.Usertype}, {product.Category.Category}");
        }
        #endregion

        #region Exercício 6 - POST com Formulário - Sem parâmetro obrigatório
        var emptyForm = new Dictionary<string,string>();
        // Chama o método para fazer uma requisição POST com dados de formulário sem o parâmetro obrigatório.
        APIMessageResponse postSearchNoParamResponse = await productAPIService.SearchProductWithouParamAPIAsync(searchUrl, emptyForm);

        // Exibe o código de resposta e a mensagem retornada.
        Console.WriteLine("\n--- Resultado da Requisição POST com Formulário - Sem parâmetro obrigatório ---");
        Console.WriteLine($"ResponseCode do JSON: {postSearchNoParamResponse.ResponseCode}");
        Console.WriteLine($"Corpo da mensagem {postSearchNoParamResponse.Message}");
        #endregion

        //Exercío 11 veio aqui primeiro por causa da necessidade de criar uma conta antes de testar os próximos exercícios.
        #region Exercício 11
        // Cria uma instância do serviço de API de login.
        LoginAPI loginApi = new LoginAPI();

        string createAccountUrl = "https://automationexercise.com/api/createAccount";

        // Gera um email único usando timestamp para evitar conflitos.
        string uniqueEmail = $"email.teste.{DateTime.Now:yyyyMMddHHmmss}@example.com";

        // Prepara os dados para criar uma nova conta.
        CreateAccountRequest request = new CreateAccountRequest
        {
            Name = "Randolfe Teste",
            Email = uniqueEmail,
            Password = "123456",

            Title = "Mr",
            BirthDate = "01",
            BirthMonth = "01",
            BirthYear = "1990",

            Firstname = "Rafael",
            Lastname = "Galozi",
            Company = "Empresa Teste",
            Address1 = "Rua A, 123",
            Address2 = "Apto 1",
            Country = "Brazil",
            Zipcode = "01000-000",
            State = "SP",
            City = "Sao Paulo",
            MobileNumber = "11999999999"
        };

        // Chama o método para criar uma nova conta.
        APIMessageResponse result = await loginApi.CreateAccountAsync(createAccountUrl, request);

        // Exibe o código de resposta e a mensagem retornada.
        Console.WriteLine("\n--- Resultado da Requisição POST para Criar Conta ---");
        Console.WriteLine($"ResponseCode do JSON: {result.ResponseCode}");
        Console.WriteLine($"Message: {result.Message}");
        // Exibe o email usado para criar a conta para futuro login.
        Console.WriteLine($"Email usado: {uniqueEmail}");
        #endregion 

        #region Exercício 7 - POST para verificar se usuário existe

        #endregion

        #region Exercício 8
        #endregion

        #region Exercício 9
        #endregion

        #region Exercício 10
        #endregion



        #region Exercício 12
        #endregion

        #region Exercício 13
        #endregion

        #region Exercício 14
        #endregion
    }
}
       