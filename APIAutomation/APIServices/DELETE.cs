using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIAutomation.APIServices
{
    internal class DELETE
    {
        // Método para enviar uma requisição DELETE e obter o status code e o corpo da resposta
        public async Task<(int StatusCode, string Body)> DeleteResponseAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url);

                int statusCode = (int)response.StatusCode;

                string responseBody = await response.Content.ReadAsStringAsync();

                return (statusCode, responseBody);
            }
        }

        // Método para enviar uma requisição DELETE com dados de formulário e obter o status code e o corpo da resposta
        public async Task<(int StatusCode, string Body)> DeleteFormAsync(string url, Dictionary<string, string> formData)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpContent content = new FormUrlEncodedContent(formData);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url))
                {
                    request.Content = content;
                    HttpResponseMessage response = await client.SendAsync(request);

                    int statusCode = (int)response.StatusCode;

                    string responseBody = await response.Content.ReadAsStringAsync();

                    return (statusCode, responseBody);
                }
                    
            }
        }
    }
}
