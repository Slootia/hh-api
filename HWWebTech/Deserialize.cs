using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HWWebTech
{
    class Deserialize
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static HttpRequestMessage _httpRequest;
        private static readonly string userAgent = "api-test-agent";
        private static readonly string url = "https://api.hh.ru/vacancies";

        private static async Task<string> SendMessage()
        {
            _httpRequest.Headers.UserAgent.Add(new ProductInfoHeaderValue("User-Agent", userAgent));

            using (var result = _httpClient.SendAsync(_httpRequest).Result)
            {
                string content = await result.Content.ReadAsStringAsync();
                return content;
            }
        }

        public static async Task<string> GetVacancy(int page)
        {         
            //Формирование запроса 
            _httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri($"{url}?page={page}&per_page=100"),
                Method = HttpMethod.Get,
            };
            string result = await SendMessage();
            return result;
        }

        public static async Task<string> GetMoreInfo(int id)
        {
            //Формирование запроса 
            _httpRequest = new HttpRequestMessage()
            {
                RequestUri = new Uri($"{url}/{id}"),
                Method = HttpMethod.Get,
            };
            string result = await SendMessage();
            return result;
        }
    }
}
