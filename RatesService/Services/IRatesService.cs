using CommonClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RatesService.Services
{
    public interface IRatesService
    {
        Task FetchAndProcessRates();
        List<InstrumentRate> GetAllRates();
    }
}
