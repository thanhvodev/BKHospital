using AppActivityIndicator.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppActivityIndicator.Services
{
    public class API
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

        public void SendEmail()
        {
            var client = new RestClient("https://api.mailjet.com/v3.1/send");
            var request = new RestRequest()
            {
                Method = Method.Post
            };
            request.AddHeader("Authorization", "Basic MDQwYTk0OWI0OGUxNmIyM2Y2MWEyMzI3ZDRhNjMxNWI6YjliNGM0NzZiZTc2NmEzN2RkYmJiYjA1ZDYwMWY3ZWQ=");
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
" + "\n" +
            @"    ""Messages"": [
" + "\n" +
            @"        {
" + "\n" +
            @"            ""From"": {
" + "\n" +
            @"                ""Email"": ""vodinhthanh123@gmail.com"",
" + "\n" +
            @"                ""Name"": ""Thanh""
" + "\n" +
            @"            },
" + "\n" +
            @"            ""To"": [
" + "\n" +
            @"                {
" + "\n" +
            @"                    ""Email"": ""vodinhthanh123@gmail.com"",
" + "\n" +
            @"                    ""Name"": ""Thanh""
" + "\n" +
            @"                }
" + "\n" +
            @"            ],
" + "\n" +
            @"            ""Subject"": ""Gymasium password"",
" + "\n" +
            @"            ""TextPart"": ""Greetings from Gymasium."",
" + "\n" +
            @"            ""HTMLPart"": ""<h3>This is your password: 123</h3>"",
" + "\n" +
            @"            ""CustomID"": ""AppGettingStartedTest""
" + "\n" +
            @"        }
" + "\n" +
            @"    ]
" + "\n" +
            @"}";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
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
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return repositories;
        }

        public async Task<List<Ward>> GetWardsAsync(string uri)
        {
            List<Ward> repositories = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    int fisrtChIndex = content.IndexOf("[");
                    string newContent = content.Substring(fisrtChIndex, content.Length - fisrtChIndex - 1);
                    repositories = JsonConvert.DeserializeObject<List<Ward>>(newContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return repositories;
        }

        public async Task<List<Country>> GetCountrysAsync(string uri)
        {
            List<Country> repositories = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    repositories = JsonConvert.DeserializeObject<List<Country>>(content);
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
