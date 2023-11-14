using Common.Models.Sources.Walutomat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Sources
{
    internal class SourceClient
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public void SetHeaderAuthorization(string key, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(key, value);
        }

        public async Task<T> Get<T>(string requestUri)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(requestUri);
            return await RetrieveResult<T>(response);
        }

        public async Task<T> Post<T>(string requestUri, IEnumerable<KeyValuePair<string, string>> postData)
        {
            using var content = new FormUrlEncodedContent(postData);
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                HttpResponseMessage response = await _httpClient.PostAsync(requestUri, content);
                return await RetrieveResult<T>(response);
            }
        }

        private async Task<T> RetrieveResult<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                T? result = await response.Content.ReadFromJsonAsync<T>();
                if (result != null)
                {
                    return result;
                }
                throw new SourceClientException();
            }
            throw new SourceClientException(response);
        }
    }
}
