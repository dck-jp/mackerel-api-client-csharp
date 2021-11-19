using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace WebAPI 
{ 
    public class Makapi
    {
        const string mackerel_api_endpoint_base = "https://api.mackerelio.com";
        private readonly HttpClient client = new HttpClient(); 
        private readonly string api_endpoint;
        private readonly string organization_name;
        public string message { get; private set; }

        public Makapi(string mackerel_apikey)
        {
            api_endpoint = mackerel_api_endpoint_base + "/api/v0";
            client.DefaultRequestHeaders.Add("X-Api-Key", mackerel_apikey);

            var r = get("org").ParseOrg();
            if(!string.IsNullOrEmpty(r.error))
            {
                message = r.error;
            }
            else
            {
                organization_name = r.name;
            }
        }

        public string build_url(string api) 
        {
            return $"{api_endpoint}/{api}";
        }

        public string get(string api) 
        {
            if (api == "org" && !string.IsNullOrEmpty(organization_name)) 
            {
                var ret = new { name = organization_name };
                return JsonSerializer.Serialize(ret);
            }
            else
            {
                var ret = client.Request(HttpMethod.Get, build_url(api)).Json();
                return ret;
            }
        }

        public string post(string api, string payloads)
        {
            var ret = client.Request(HttpMethod.Post, build_url(api), payloads).Json();
            return ret;
        }

        public string put(string api) 
        {
            var ret = client.Request(HttpMethod.Put, build_url(api)).Json();
            return ret;
        }

        public string delete(string api) 
        {
            var ret = client.Request(HttpMethod.Delete, build_url(api)).Json();
            return ret;
        }
    }

    /// <summary>
    /// Makapi本体のコードを本家Pythonのコードとほぼ同一の処理の流れにするための拡張メソッド群
    /// </summary>
    public static class MakapiExtension
    {
        public static HttpResponseMessage Request(this HttpClient client, HttpMethod method, string url, string payloads = null) 
        {
            var request = new HttpRequestMessage(method, url);
            if(!string.IsNullOrEmpty(payloads)) 
            {
                request.Content = new StringContent(payloads, Encoding.UTF8, "application/json");
            }
            return client.SendAsync(request).Result;
        }

        public static string Json(this HttpResponseMessage response) 
        {
            return response.Content.ReadAsStringAsync().Result;
        }

        public static OrgResponse ParseOrg(this string json)
        {
            return JsonSerializer.Deserialize<OrgResponse>(json);
        }

        public class OrgResponse
        {
            public string name { get; set; }
            public string error { get; set; }
        }
    }

}
