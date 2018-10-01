using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using purchaseapp.Request.Models;
using Newtonsoft.Json;

namespace purchaseapp.Util{
    public class ClientRequest{

        private HttpClient _client;

        public ClientRequest(String baseUrl){
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseUrl);
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("MerchantId","ac780022-dba5-488b-819f-64c042264214");
            _client.DefaultRequestHeaders.Add("MerchantKey","UDNUPPOTMBPDQJDDSNWNKQULVBHBXOTGAOHEUBTF");
        }

        public async Task<String> RealizarCompraAsync(Transaction dadosComprador){
            HttpResponseMessage response = await _client.PostAsJsonAsync<Transaction>("v2/sales", dadosComprador);
            
            
            JsonConvert.SerializeObject(dadosComprador).ToString();

            // response.EnsureSuccessStatusCode();

            return JsonConvert.SerializeObject(dadosComprador).ToString();
        }

    }
}