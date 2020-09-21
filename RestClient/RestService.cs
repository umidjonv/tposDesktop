using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestService
{
    public class RestService
    {
        private readonly RestClient  _client;
        public RestService()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            _client = new RestClient("https://localhost:5001");

            //client.DefaultParameters.Add(new Parameter("Authorization", string.Format("Bearer " + PERSONAL_ACCESS_TOKEN), ParameterType.HttpHeader));

            //var request = new RestRequest("budgets/last-used/months/current/categories/{category_id}", Method.PATCH);
            //request.AddUrlSegment("category_id", categoryId);

            //request.AddJsonBody(new { category = new { budgeted = 120000 } });
            //// Or
            //// request.AddParameter("text/json", "{\"category\": { \"budgeted\": 120000 }", ParameterType.RequestBody);

            //IRestResponse response = client.Execute(request);
            //var content = response.Content;
        }

        public async void AddExpense(string row)
        {
            var request = new RestRequest("/api/expense", Method.POST);
            
            //request.AddJsonBody(new { category = new { budgeted = 120000 } });
            request.AddParameter("text/json", row, ParameterType.RequestBody);

            IRestResponse response = await _client.ExecuteAsync(request);

        }

        public async void AddIncome(string row)
        {
            var request = new RestRequest("api/income/add", Method.POST);

            request.AddParameter("text/json", row, ParameterType.RequestBody);

            IRestResponse response = await _client.ExecuteAsync(request);
            var content = response.Content;
            
        }

        public async void EditIncome(int id, string row)
        {
            var request = new RestRequest("api/income/edit", Method.POST);

            //request.AddJsonBody(new { category = new { budgeted = 120000 } });
            request.AddParameter("id", id, ParameterType.UrlSegment);
            request.AddParameter("text/json", row, ParameterType.RequestBody);
            

            IRestResponse response = await _client.ExecuteAsync(request);
            var content = response.Content;



        }

        public async void DeleteIncome(int id)
        {
            var request = new RestRequest("api/income/delete/{id}", Method.GET);

            //request.RequestFormat = DataFormat.Json;
            //request.AddJsonBody(new { category = new { budgeted = 120000 } });
            request.AddParameter("id", id, ParameterType.UrlSegment);
            
            IRestResponse response = await _client.ExecuteAsync(request);
            var content = response.Content;



        }
    }
}
