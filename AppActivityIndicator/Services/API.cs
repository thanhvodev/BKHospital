using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppActivityIndicator.Services
{
    internal class API
    {
        private readonly HttpClient _client;
        private static API instance = null;

        public static API GetInstance()
        {
            if (instance == null)
            {
                instance = new API();
                return instance;
            }
            else
            {
                return instance;
            }
        }

        private API()
        {
                _client = new HttpClient();
        }

        public async Task<List<Province>> GetProvincesAsync(string uri)
        {
            List<Province> repositories = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    repositories = JsonConvert.DeserializeObject<List<Province>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return repositories;
        }

        public async Task<List<District>> GetDistrictsAsync(string uri)
        {
            List<District> repositories = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    int fisrtChIndex = content.IndexOf("[");
                    string newContent = content.Substring(fisrtChIndex, content.Length - fisrtChIndex - 1);
                    repositories = JsonConvert.DeserializeObject<List<District>>(newContent);
                    Debug.WriteLine(newContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return repositories;
        }
    }
}
