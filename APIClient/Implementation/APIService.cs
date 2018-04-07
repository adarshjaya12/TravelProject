using APIClient.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace APIClient.Implementation
{
    public class APIService : IAPIService
    {
        // Get Method
        HttpClient _client;
        HttpClient Client
        {
            get
            {
                if (_client == null)
                    Intialize();
                return _client;
            }
        }

        private void Intialize()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://maps.googleapis.com/maps/api/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<T>> GetCollectionAsync<T>(string path)
        {
            List<T> t = new List<T>();

            HttpResponseMessage response = await Client.GetAsync(path)
                .ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                t = await response.Content.ReadAsAsync<List<T>>()
                .ConfigureAwait(false);
            }
            return t;
        }

        public async Task<T> GetItemAsync<T>(string path)
        {
            T t = default(T);
            HttpResponseMessage response = await Client.GetAsync(path)
                .ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                t = await response.Content.ReadAsAsync<T>();
            }
            return t;
        }
    }
}
