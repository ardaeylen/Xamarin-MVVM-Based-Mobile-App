using Last.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Last.HttpHandler;
namespace Last.Services
{
    public class UserRestService //RestAPI'ler HTTP ile haberleşir
    {
        public HttpClient client;
        public UserRestService()
        {
            
           HttpClientHandler insecureHandler =BypassingTheCertificate.GetInsecureHandler();
            Client = new HttpClient(insecureHandler);
        }

        public HttpClient Client { get => client; set => client = value; }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            User user = new User();
            NameValueCollection queeryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queeryString.Add("username", username);
            queeryString.Add("password", password);
            var uri = new Uri(Constants.BaseUserAddress + "?" + queeryString.ToString());
            try
            {
                HttpResponseMessage response = await Client.GetAsync(uri).ConfigureAwait(false);
                if (response.IsSuccessStatusCode )
                {
                    string content = await response.Content.ReadAsStringAsync();//Gelen JSON nesnesini string hale çevirmek için..
                    user = JsonConvert.DeserializeObject<User>(content); // gelen cevap bir adet user nesnesine dönüştürülüyor
                }

            }
            catch(Exception ex)
            {
                return null;
            }
            return user;
        }
        public async Task<string> AddUser(User user)
        {
            string result = "";
            var uri = new Uri(Constants.BaseUserAddress);
            try
            {
                var json = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");//Json nesnesini UTF-8 formatında ( ve Mediatype:application) olarak content in içine atıyor
                HttpResponseMessage response = await Client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();

                }
            }
            catch 
            {
                return null;
            }
            return result;
        }


    }
}
