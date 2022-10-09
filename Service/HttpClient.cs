using MyToToDemo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public class HttpClient
    {
        private readonly string apiUrl;
        private readonly RestClient restClient;

        public HttpClient(string apiUrl)
        {
            this.restClient = new RestClient();
            this.apiUrl = apiUrl;
        }

        public async Task<Response> ExectAsync(RequestParams parammater)
        {
            restClient.BaseUrl = new Uri(apiUrl + parammater.Route);
            var restRequest = new RestRequest(parammater.Method);
            restRequest.AddHeader("Content-Type",parammater.ContentType);
            if (parammater.Param != null)
            {
                restRequest.AddParameter("param", JsonConvert.SerializeObject(parammater.Param), ParameterType.RequestBody);
            }
            var response = await restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<Response>(response.Content);
            else
                return new Response 
                {
                    Status = false,
                    Message = response.ErrorMessage,
                    Data = null
                };
        }

        public async Task<Response<T>> ExectAsync<T>(RequestParams parammater)
        {
            restClient.BaseUrl = new Uri(apiUrl + parammater.Route);
            var restRequest = new RestRequest(parammater.Method);
            restRequest.AddHeader("Content-Type", parammater.ContentType);
            if (parammater.Param != null)
            {
                restRequest.AddParameter("param", JsonConvert.SerializeObject(parammater.Param), ParameterType.RequestBody);
            }
            var response = await restClient.ExecuteAsync(restRequest);
            if (response.IsSuccessful)
                return JsonConvert.DeserializeObject<Response<T>>(response.Content);
            else
                return new Response<T>
                {
                    Status = false,
                    Message = response.ErrorMessage
                };
        }
    }
}
