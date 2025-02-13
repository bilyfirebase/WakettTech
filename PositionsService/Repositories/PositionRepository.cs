using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PositionsService.Repositories;
using PositionsService.Services;
using CommonClasses.Models;
using System.Collections.Concurrent;
using PositionsService.Infrastructure;

namespace PositionsService.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ConcurrentBag<Position> _positions = new();

        public PositionRepository()
        {
            var positionsFromCsv = CsvLoader.LoadPositionsFromCsv("positions.csv");
            foreach (var position in positionsFromCsv)
            {
                _positions.Add(position);
            }
        }

        public List<Position> GetAllPositions()
        {
            return _positions.ToList();
        }

        public void AddPosition(Position position)
        {
            _positions.Add(position);
        }

        public List<Position> GetPositionsByInstrument(string instrumentId)
        {
            return _positions.Where(p => p.InstrumentId == instrumentId).ToList();
        }
    }
}
