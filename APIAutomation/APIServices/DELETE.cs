using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIAutomation.APIServices
{
    internal class DELETE
    {
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
    }
}
