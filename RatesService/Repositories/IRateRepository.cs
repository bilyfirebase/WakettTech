using CommonClasses.Models;
using System.Collections.Generic;

namespace RatesService.Repositories
{
    public interface IRateRepository
    {
        List<InstrumentRate> GetAllRates();
        void SaveRate(InstrumentRate rate);
    }
}
