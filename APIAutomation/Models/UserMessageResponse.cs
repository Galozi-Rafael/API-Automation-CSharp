using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace APIAutomation.Models
{
    internal class UserMessageResponse
    {
        [JsonPropertyName("responseCode")]
        public int ResponseCode { get; set; }

        [JsonPropertyName("user")]
        public UserDetail User { get; set; }

        override public string ToString()
        {
            return $"UserMessageResponse: ResponseCode={ResponseCode}, User=({User})";
        }

    }
}
