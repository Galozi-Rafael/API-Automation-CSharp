using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIAutomation.APIServices
{
    internal class POST
    {
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
    }
}
