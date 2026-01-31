using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace APIAutomation.APIServices
{
    internal class PUT
    {
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
    }
}