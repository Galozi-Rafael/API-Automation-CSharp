using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace APIAutomation.APIServices
{
    internal class PUT
    {
        // Método para enviar uma requisição PUT com corpo JSON
        public async Task<(int StatusCode, string Body)> PutResponseAsync(string url, string jsonBody = null)
        {
            using (var httpClient = new HttpClient())
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpContent content = null;
                    if (jsonBody != null)
                    {
                        content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    }

                    HttpResponseMessage response = await client.PutAsync(url, null);

                    int statusCode = (int)response.StatusCode;

                    string responseBody = await response.Content.ReadAsStringAsync();

                    return (statusCode, responseBody);
                }
            }
        }
        
        // Método para enviar dados de formulário via PUT
        public async Task<(int StatusCode, string Body)> PutFormAsync(string url, Dictionary<string, string> formData)
        {
            using (var httpClient = new HttpClient())
            {
                using (HttpClient client = new HttpClient())
                {
                    var content = new FormUrlEncodedContent(formData);

                    HttpResponseMessage response = await client.PutAsync(url, content);

                    int statusCode = (int)response.StatusCode;

                    string responseBody = await response.Content.ReadAsStringAsync();

                    return (statusCode, responseBody);
                }
            }
        }
    }
}