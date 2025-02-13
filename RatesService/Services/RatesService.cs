using CommonClasses.Models;
using RatesService.Repositories;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace RatesService.Services
{
    public class RatesService : IRatesService
    {
        private readonly IRateRepository _rateRepository;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public RatesService(IRateRepository rateRepository, IConfiguration configuration)
        {
            _rateRepository = rateRepository;
            _httpClient = new HttpClient();
            _configuration = configuration;
        }

        public async Task FetchAndProcessRates()
        {
            Console.WriteLine("🔄 Fetching rates from CoinMarketCap...");

            string apiKey = "1478e3f8-d9a1-4572-8812-5c548a259b46";
            string url = "https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest?convert=USD";

            _httpClient.DefaultRequestHeaders.Clear(); // Ensure no duplicate headers
            _httpClient.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", apiKey);

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            Console.WriteLine($"🌐 API Call Response: {(int)response.StatusCode} {response.ReasonPhrase}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("❌ API call failed. Check API key and internet.");
                return;
            }

            string json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"📜 JSON Response: {json.Substring(0, 500)}..."); // Print first 500 chars

            var rates = ParseRates(json);
            Console.WriteLine($"📊 Parsed {rates.Count} rates.");

            foreach (var rate in rates)
            {
                Console.WriteLine($"💾 Saving Rate: {rate.Symbol} - {rate.Rate}");
                _rateRepository.SaveRate(rate);
            }
        }


        public List<InstrumentRate> GetAllRates()
        {
            return _rateRepository.GetAllRates();
        }

        private List<InstrumentRate> ParseRates(string json)
        {
            var document = JsonDocument.Parse(json);
            var rates = new List<InstrumentRate>();

            foreach (var item in document.RootElement.GetProperty("data").EnumerateArray())
            {
                string symbol = item.GetProperty("symbol").GetString();
                decimal rate = item.GetProperty("quote").GetProperty("USD").GetProperty("price").GetDecimal();

                rates.Add(new InstrumentRate { Symbol = symbol, Rate = rate, Timestamp = DateTime.UtcNow });
            }

            return rates;
        }
    }
}
