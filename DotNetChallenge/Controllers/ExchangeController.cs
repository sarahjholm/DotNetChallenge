using DotNetChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DotNetChallenge.Controllers
{
    public class ExchangeController
    {
        static HttpClient client = new HttpClient();

        public static async Task<ApiResponse> GetExchangeInfoAsync(ExchangeRequest exchangeRequest)
        {
            var path = GetPath(exchangeRequest);
            ApiResponse apiResponse = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                apiResponse = await response.Content.ReadAsAsync<ApiResponse>();
            }
            return apiResponse;
        }

        public static String GetPath(ExchangeRequest exchangeRequest)
        {
            var apiKey = exchangeRequest.apiKey;
            var currencyFrom = exchangeRequest.currencyFrom;
            var currencyTo = exchangeRequest.currencyTo;
            var amount = exchangeRequest.amount;

            var path = "";

            if (amount == 1) {
                path = $"https://www.amdoren.com/api/currency.php?api_key={apiKey}&from={currencyFrom}&to={currencyTo}";
            } else {
                path = $"https://www.amdoren.com/api/currency.php?api_key={apiKey}&from={currencyFrom}&to={currencyTo}&amount={amount}";
            }
            return path;
        }
    }
}
