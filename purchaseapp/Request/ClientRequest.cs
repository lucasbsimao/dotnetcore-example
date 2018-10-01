using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using purchaseapp.Request.Models;
using Newtonsoft.Json;
using System.Text;
using RestSharp;
using System.Net;
using System.Collections.Generic;

namespace purchaseapp.Util{
    public class ClientRequest{

        private RestClient _client;
        private string _baseUrl;

        public ClientRequest(string baseUrl){
            this._client = new RestClient();
            this._baseUrl = baseUrl;
        }

        public string RealizarAutorizacao(Transaction dadosComprador)
        {
            _client.BaseUrl = new Uri(this._baseUrl);
            var request = new RestRequest("/v2/sales", Method.POST);

            var response = this.CriarEscopoTransacao(request, dadosComprador);

            return JsonConvert.DeserializeObject(response.Content).ToString();
        }

        public string RealizarCompra(string purchaseId)
        {
            _client.BaseUrl = new Uri(this._baseUrl);
            var request = new RestRequest("/v2/sales/" + purchaseId + "/capture", Method.PUT);
            var response = this.CriarEscopoTransacao(request, (object)null);
            return JsonConvert.DeserializeObject(response.Content).ToString();
        }

        public string RealizarCancelamento(string purchaseId)
        {
            _client.BaseUrl = new Uri(this._baseUrl);
            var request = new RestRequest("/v2/sales/" + purchaseId + "/void", Method.PUT);
            var response = this.CriarEscopoTransacao(request, (object)null);
            return JsonConvert.DeserializeObject(response.Content).ToString();
        }

        private IRestResponse CriarEscopoTransacao<T>(RestRequest request, T payload)
        {
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;

            request.AddParameter("MerchantKey", "UDNUPPOTMBPDQJDDSNWNKQULVBHBXOTGAOHEUBTF", ParameterType.HttpHeader);
            request.AddParameter("MerchantId", "ac780022-dba5-488b-819f-64c042264214", ParameterType.HttpHeader);
            request.AddParameter("RequestId", Guid.NewGuid(), ParameterType.HttpHeader);

            if(!EqualityComparer<T>.Default.Equals(payload, default(T))){
                Console.WriteLine("Treta braba");
                request.AddParameter("application/json",
                    JsonConvert.SerializeObject(payload, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                    ParameterType.RequestBody);
            }

            var response = _client.Execute(request);

            if ((response.StatusCode != HttpStatusCode.OK) &&
                (response.StatusCode != HttpStatusCode.Created))
                throw new Exception("Operação de compra não executada. Status: " + response.StatusCode + ".");

            return response;
        }
    }
}