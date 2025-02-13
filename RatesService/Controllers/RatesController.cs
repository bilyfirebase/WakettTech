using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RatesService.Services;

namespace RatesService.Controllers
{
    [ApiController]
    [Route("api/rates")]
    public class RatesController : ControllerBase
    {
        private readonly IRatesService _ratesService;

        public RatesController(IRatesService ratesService)
        {
            _ratesService = ratesService;
        }

        [HttpPost("fetch")]
        public async Task<IActionResult> FetchRates()
        {
            await _ratesService.FetchAndProcessRates();
            return Ok("Rates fetched and processed.");
        }

        [HttpGet]
        public IActionResult GetAllRates()
        {
            var rates = _ratesService.GetAllRates();
            return Ok(rates);
        }
    }
}
