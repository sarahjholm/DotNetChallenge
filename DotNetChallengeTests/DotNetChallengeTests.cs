using DotNetChallenge.Controllers;
using DotNetChallenge.Models;

namespace DotNetChallengeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetExchangeInfo_WithAmount1_ShouldReturnInfo()
        {
            var exchangeRequest = new ExchangeRequest
            {
                apiKey = "af8SekucDF7Sdu8KJzbTN6FDamT2CT",
                currencyFrom = "EUR",
                currencyTo = "USD",
                amount = 1
            };

            var expectedResponse = new ApiResponse
            {
                error = 0,
                error_message = "-",
                amount = 1.04141
            };

            var apiResponse = await ExchangeController.GetExchangeInfoAsync(exchangeRequest);

            Assert.That(apiResponse, Is.EqualTo(expectedResponse));
        }

        [Test]
        public void GetPath_ShouldReturnPath_ForCurrencyConversion()
        {
            var exchangeRequest = new ExchangeRequest
            {
                apiKey = "af8SekucDF7Sdu8KJzbTN6FDamT2CT",
                currencyFrom = "EUR",
                currencyTo = "USD",
                amount = 1
            };

            var path = ExchangeController.GetPath(exchangeRequest);

            Assert.That(true, path,
                Equals("https://www.amdoren.com/api/currency.php?api_key=af8SekucDF7Sdu8KJzbTN6FDamT2CT&from=EUR&to=USD"));

        }

        [Test]
        public void GetPath_ShouldReturnPath_ForExchangeRate()
        {
            var exchangeRequest = new ExchangeRequest
            {
                apiKey = "af8SekucDF7Sdu8KJzbTN6FDamT2CT",
                currencyFrom = "EUR",
                currencyTo = "USD",
                amount = 50
            };

            var path = ExchangeController.GetPath(exchangeRequest);

            Assert.That(true, path,
                Equals("https://www.amdoren.com/api/currency.php?api_key=af8SekucDF7Sdu8KJzbTN6FDamT2CT&from=EUR&to=USD&amount=50"));

        }

    }
}