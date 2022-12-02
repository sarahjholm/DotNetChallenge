using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using DotNetChallenge.Models;
using DotNetChallenge.Controllers;

namespace DotNetChallenge
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            var showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }
        }

        private static bool Menu()
        {
            var exchangeRequest = new ExchangeRequest
            {
                apiKey = "af8SekucDF7Sdu8KJzbTN6FDamT2CT" // Change API key here; only 10 free calls per month
            };

            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(" Welcome to the Free Currency Converter!");
            Console.WriteLine("-----------------------------------------\n");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("     1) Convert currency");
            Console.WriteLine("     2) Get exchange rate");
            Console.WriteLine("     3) Exit");
            Console.Write("\r\nInsert option here: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Write("\r\nAmount to convert: ");
                    exchangeRequest.amount = double.Parse(Console.ReadLine());
                    ExchangeMenu(exchangeRequest);
                    return true;
                case "2":
                    ExchangeMenu(exchangeRequest);
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }

        private static void ExchangeMenu(ExchangeRequest exchangeRequest)
        {
            Console.WriteLine("\r\nNow please choose your currency to...");
            Console.Write("     - Convert from: ");
            exchangeRequest.currencyFrom = Console.ReadLine();
            Console.Write("     - Convert to: ");
            exchangeRequest.currencyTo = Console.ReadLine();

            var apiResponse = ExchangeController.GetExchangeInfoAsync(exchangeRequest)
                                                    .GetAwaiter().GetResult();

            if (OperationSuccess(apiResponse))
            {
                DisplayResult(apiResponse, exchangeRequest);
            }
            else
            {
                Console.WriteLine($"\r\nOperation failed with the following error: \"{apiResponse.error_message}\"");
                Console.WriteLine("Press Enter to return to the Main Menu");
                Console.ReadLine();
            }
        }

        private static void DisplayResult(ApiResponse apiResponse, ExchangeRequest exchangeRequest)
        {
            var currencyFrom = exchangeRequest.currencyFrom.ToUpper();
            var currencyTo = exchangeRequest.currencyTo.ToUpper();
            var amount = exchangeRequest.amount;

            var convertedCurrency = apiResponse.amount;

            Console.WriteLine("\r\nConversion Success!");
            Console.WriteLine($"{amount} {currencyFrom} => EQUIVALENT TO => {convertedCurrency} {currencyTo}");
            Console.WriteLine("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();

        }

        private static bool OperationSuccess(ApiResponse apiResponse)
        {
            if (apiResponse.error_message.Equals("-"))
                return true;
            return false;
        }


    }
}
