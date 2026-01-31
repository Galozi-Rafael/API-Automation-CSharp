using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIAutomation.APIServices
{
    internal class POST
    {
        // Método para fazer uma requisição POST e retornar o código de status e o corpo da resposta.
        public async Task<(int StatusCode, string Body)> PostResponseAsync(string url, string jsonBody = null)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = null;
                if (jsonBody != null)
                {
                    content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                }

                HttpResponseMessage response = await client.PostAsync(url, null);

                int statusCode = (int)response.StatusCode;

                string responseBody = await response.Content.ReadAsStringAsync();

                return (statusCode, responseBody);
            }
        }

        // Método para fazer uma requisição POST com dados de formulário e retornar o código de status e o corpo da resposta.
        public async Task<(int StatusCode, string Body)> PostFormAsync(string url, Dictionary<string, string> formData)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new FormUrlEncodedContent(formData);
                {
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    int statusCode = (int)response.StatusCode;

                    string responseBody = await response.Content.ReadAsStringAsync();

                    return (statusCode, responseBody);
                }

            }
        }
    }
}

   
