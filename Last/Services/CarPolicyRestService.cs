using Last.HttpHandler;
using Last.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Last.Services
{
    public class CarPolicyRestService
    {
        private HttpClient client;

        public HttpClient Client { get => client; set => client = value; }
        public CarPolicyRestService()
        {
            HttpClientHandler insecureHandler = BypassingTheCertificate.GetInsecureHandler();
            Client = new HttpClient(insecureHandler);
        }
        public async Task<CarPolicy> GetCarPolicy(int policeno)
        {
            CarPolicy carPolicy = new CarPolicy();
            NameValueCollection queeryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queeryString.Add("policeno", policeno.ToString());
            var uri = new Uri(Constants.BaseCarPolicyAddress + "?" + queeryString.ToString());
            try
            {
                var response = await client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    carPolicy = JsonConvert.DeserializeObject<CarPolicy>(content);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return carPolicy;
        }
        public async Task<string> AddCarPolicy(CarPolicy carPolicy)
        {
            var uri = new Uri(Constants.BaseCarPolicyAddress);
            string result = "";
            try
            {
                var jsonObject = JsonConvert.SerializeObject(carPolicy);
                StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }

            }
            catch(Exception ex)
            {
                return null;
            }
            return result;
        }

    }
}
