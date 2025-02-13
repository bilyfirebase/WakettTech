using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PositionsService.Repositories;
using PositionsService.Services;
using CommonClasses.Models;

namespace PositionsService.Controllers
{
    [ApiController]
    [Route("api/positions")]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionsService _positionsService;

        public PositionsController(IPositionsService positionsService)
        {
            _positionsService = positionsService;
        }

        [HttpGet]
        public IActionResult GetAllPositions()
        {
            var positions = _positionsService.GetAllPositions();
            return Ok(positions);
        }

        [HttpPost]
        public IActionResult AddPosition([FromBody] Position position)
        {
            _positionsService.AddPosition(position);
            return Ok("Position added successfully.");
        }

        [HttpPost("update-rates")]
        public IActionResult UpdatePositions([FromBody] RateChangeEvent rateChangeEvent)
        {
            Console.WriteLine($"Received Rate Update for {rateChangeEvent.Symbol}: {rateChangeEvent.NewRate}");
            _positionsService.UpdatePositions(rateChangeEvent.Symbol, rateChangeEvent.NewRate);
            return Ok("Profit/Loss updated.");
        }

        [HttpGet("by-instrument/{instrumentId}")]
        public IActionResult GetPositionsByInstrument(string instrumentId)
        {
            var positions = _positionsService.GetPositionsByInstrument(instrumentId);

            if (positions.Count == 0)
            {
                return NotFound($"No positions found for {instrumentId}");
            }

            return Ok(positions);
        }
    }
}
