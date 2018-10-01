using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using purchaseapp.Request.Models;
using Newtonsoft.Json;
using System.Text;
using RestSharp;

namespace purchaseapp.Util{
    public class ClientRequest{

        private RestClient _client;
        private string _baseUrl;

        public ClientRequest(string baseUrl){
            this._client = new RestClient();
            this._baseUrl = baseUrl;
        }

        public string RealizarCompra(Transaction dadosComprador)
        {
            _client.BaseUrl = new Uri(this._baseUrl);
            var request = new RestRequest("/v2/sales", Method.POST);

            request.AddParameter("MerchantKey", "UDNUPPOTMBPDQJDDSNWNKQULVBHBXOTGAOHEUBTF", ParameterType.HttpHeader);
            request.AddParameter("MerchantId", "ac780022-dba5-488b-819f-64c042264214", ParameterType.HttpHeader);
            request.AddParameter("RequestId", Guid.NewGuid(), ParameterType.HttpHeader);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("application/json",
                JsonConvert.SerializeObject(dadosComprador, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                ParameterType.RequestBody);

            var response = _client.Execute(request);

            return JsonConvert.DeserializeObject(response.Content).ToString();
        }

    }
}