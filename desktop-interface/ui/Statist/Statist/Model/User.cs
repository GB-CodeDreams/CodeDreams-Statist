using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Statist.Model
{
    public static class User
    {
        [JsonProperty(PropertyName = "id")]
        public static string Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public static string Name { get; set; }

        [JsonProperty(PropertyName = "token")]
        public static string Token { get; set; }
    }
}
