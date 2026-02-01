using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using APIAutomation.Models;
using APIAutomation.APIServices;

namespace APIAutomation.Services
{
    internal class LoginAPI
    {
        private readonly POST _apiPOST;
        private readonly JsonSerializerOptions _jsonOptions;

        //  Construtor da classe LoginAPI
        public LoginAPI()
        {
            _apiPOST = new POST();
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        // Método para criar uma conta
        public async Task<APIMessageResponse> CreateAccountAsync(string url, CreateAccountRequest Request)
        {
            Dictionary<string, string> formData = BuilCreateAccountForm(Request);

            var response = await _apiPOST.PostFormAsync(url, formData);

            APIMessageResponse apiResponse = JsonSerializer.Deserialize<APIMessageResponse>(response.Body, _jsonOptions);

            if (apiResponse == null)
            {
                throw new Exception("Failed to deserialize API response.");
            }

            return apiResponse;
        }

        // Método privado para construir o formulário de criação de conta
        private Dictionary<string, string> BuilCreateAccountForm(CreateAccountRequest request)
        {
            return new Dictionary<string, string>
            {
                { "name", request.Name },
                { "email", request.Email },
                { "password", request.Password },
                { "title", request.Title },
                { "birth_date", request.BirthDate },
                { "birth_month", request.BirthMonth },
                { "birth_year", request.BirthYear },
                { "firstname", request.Firstname },
                { "lastname", request.Lastname },
                { "company", request.Company },
                { "address1", request.Address1 },
                { "address2", request.Address2 },
                { "country", request.Country },
                { "zipcode", request.Zipcode },
                { "state", request.State },
                { "city", request.City },
                { "mobile_number", request.MobileNumber }
            };
        }

        // Método para verificar login
        public async Task<APIMessageResponse> VerifyLoginAsync(string url, Dictionary<string, string> loginData)
        {
            var response = await _apiPOST.PostFormAsync(url, loginData);
            APIMessageResponse apiResponse = JsonSerializer.Deserialize<APIMessageResponse>(response.Body, _jsonOptions);
            
            if (apiResponse == null)
            {
                throw new Exception("Failed to deserialize API response.");
            }
            return apiResponse;
        }

    }
}
