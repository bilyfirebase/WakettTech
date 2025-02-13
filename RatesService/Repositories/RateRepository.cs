using CommonClasses.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace RatesService.Repositories
{
    public class RateRepository : IRateRepository
    {
        private readonly ConcurrentBag<InstrumentRate> _rates = new();

        public List<InstrumentRate> GetAllRates()
        {
            Console.WriteLine($"📤 Retrieving {_rates.Count} stored rates.");

            foreach (var rate in _rates)
            {
                Console.WriteLine($"✅ Stored Rate: {rate.Symbol} - {rate.Rate}");
            }

            return _rates.ToList();
        }

        public void SaveRate(InstrumentRate rate)
        {
            Console.WriteLine($"💾 Storing Rate: {rate.Symbol} - {rate.Rate}");
            _rates.Add(rate);
            Console.WriteLine($"📊 Total rates stored: {_rates.Count}");
        }

    }
}
