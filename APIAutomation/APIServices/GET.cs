using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIAutomation.APIServices
{
    // Define a classe GET para realizar requisições GET
    // Esse método pode ser utilizado para testar endpoints de APIs RESTful
    // e obter dados de servidores web
    internal class GET
    {
        public async Task<string> GetResponseAsync(string url)
        {
            // Cria uma instância de HttpClient
            using (HttpClient client = new HttpClient())
            {
                // Envia a requisição GET e obtém a resposta
                HttpResponseMessage response = await client.GetAsync(url);

                int statusCode = (int)response.StatusCode;
                
                string responseBody = await response.Content.ReadAsStringAsync();

                return "O código de status é: " + statusCode + "\n\n" + responseBody;
                
            }
        }
    }
}
