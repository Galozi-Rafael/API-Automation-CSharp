using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace APIAutomation.Models
{
    internal class UserDetail
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("birth_day")]
        public string BirthDay { get; set; }

        [JsonPropertyName("birth_month")]
        public string BirthMonth { get; set; }

        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("address1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address2")]
        public string Address2 { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("zipcode")]
        public string Zipcode { get; set; }

        override public string ToString()
        {
            return $"UserDetail: Id={Id}, Name={Name}, Email={Email}, Title={Title}, BirthDay={BirthDay}, BirthMonth={BirthMonth}, BirthYear={BirthYear}, FirstName={FirstName}, LastName={LastName}, Company={Company}, Address1={Address1}, Address2={Address2}, Country={Country}, State={State}, City={City}, Zipcode={Zipcode}";
        }
    }
}
