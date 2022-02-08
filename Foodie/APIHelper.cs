using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Foodie
{
    class APIHelper
    {
        private static readonly string baseURL = "https://api.yelp.com/v3/key=MmIwF6_yIaXwo1eoyOlcpQT66D2id5uIu1zLYkJy1gWnflagFXPfHwfAdqR0GuPCYsnVrt85GJK6MousAP1qnVH5-PdTuXl3_RbvXhGEqE44yCS8rVUJ6-eECQlBYXYx/businesses/search?";
        //private static readonly string key = "key=MmIwF6_yIaXwo1eoyOlcpQT66D2id5uIu1zLYkJy1gWnflagFXPfHwfAdqR0GuPCYsnVrt85GJK6MousAP1qnVH5-PdTuXl3_RbvXhGEqE44yCS8rVUJ6-eECQlBYXYx";
        public static async Task<string> Get(string id, string type)
        {
            var inputData = new Dictionary<string, string>
            {
                { "id" , id},
                { "type" , type}
            };
            var input = new FormUrlEncodedContent(inputData);
            using(HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL +"location"+ input))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if(data != null)
                        {
                            return data;
                        }
                    }

                }
            }
            return string.Empty;
        } 
        public static string BeautifyJson(string jsonStr)
        {
            JToken parseJson = JToken.Parse(jsonStr);
            return parseJson.ToString(Formatting.Indented);
        }
    }

}
