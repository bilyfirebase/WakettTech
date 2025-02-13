using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonClasses.Models;
using PositionsService.Repositories;

namespace PositionsService.Services
{
    public class PositionsService : IPositionsService
    {
        private readonly IPositionRepository _positionRepository;

        public PositionsService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public List<Position> GetAllPositions()
        {
            return _positionRepository.GetAllPositions();
        }

        public void AddPosition(Position position)
        {
            _positionRepository.AddPosition(position);
        }

        public List<Position> GetPositionsByInstrument(string instrumentId)
        {
            var positions = _positionRepository.GetPositionsByInstrument(instrumentId);
            Console.WriteLine($"📤 Retrieving positions for {instrumentId}: Found {positions.Count} positions.");

            return positions;
        }

        public void UpdatePositions(string instrumentId, decimal newRate)
        {
            var positions = _positionRepository.GetPositionsByInstrument(instrumentId);

            foreach (var position in positions)
            {
                decimal oldProfitLoss = position.CalculateProfitOrLoss(position.InitialRate);
                decimal newProfitLoss = position.CalculateProfitOrLoss(newRate);

                Console.WriteLine($"Updating {position.InstrumentId}:");
                Console.WriteLine($"Old P/L: {oldProfitLoss} USD");
                Console.WriteLine($"New P/L: {newProfitLoss} USD");

                // We can later store this in a database or publish an event
            }
        }
    }
}
