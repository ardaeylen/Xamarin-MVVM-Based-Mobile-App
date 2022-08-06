using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Last.HttpHandler;
using Last.Models;
using Newtonsoft.Json;

namespace Last.Services
{
    public class PolicyRestService
    {
        private HttpClient client;
        public PolicyRestService()
        {
            HttpClientHandler insecureHandler = BypassingTheCertificate.GetInsecureHandler();
            Client = new HttpClient(insecureHandler);
        }

        public HttpClient Client { get => client; set => client = value; }
        public async Task<List<Policy>> GetPoliciesAsync(int userid)
        {
            List<Policy> policies = new List<Policy>();
            NameValueCollection queeryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queeryString.Add("userid", userid.ToString());
            var uri = new Uri(Constants.BasePolicyAddress + "?" + queeryString.ToString());
            try
            {
                var response = await client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    policies = JsonConvert.DeserializeObject<List<Policy>>(content);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            return policies;
        }
        public async Task<string> AddPolicy(Policy policy)
        {
            string result="";
            var uri = new Uri(Constants.BasePolicyAddress);
            try
            {
                var jsonObject = JsonConvert.SerializeObject(policy);
                StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");//Provides Http Content Based On A String.
                var response = await client.PostAsync(uri, content);
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
        public async Task<string> DeletePolicy(int policyid)
        {
            string result = "";
            NameValueCollection queeryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queeryString.Add("policeno", policyid.ToString());
            var uri = new Uri(Constants.BasePolicyAddress + "?" + queeryString.ToString());
            try
            {
                var response = await client.DeleteAsync(uri);
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
