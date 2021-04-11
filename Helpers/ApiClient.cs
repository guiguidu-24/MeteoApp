using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace MeteoApp
{
    public class ApiClient
    {
        private readonly HttpClient client = new HttpClient();

        public string Token
        {
            set
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",value);
            }
        }
        

        public async Task<dynamic> GetJsonAsync(Uri uri)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            try
            {
                string response = await client.GetStringAsync(uri);
                dynamic json = JsonConvert.DeserializeObject(response);
                return json;
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show("A request exception just occured : " + e.Message, "request exception",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                //Application.Current.Shutdown();
            }

            return default(string);
        }
    }
}