using CommonClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PositionsService.Repositories
{
    public interface IPositionRepository
    {
        List<Position> GetAllPositions();
        List<Position> GetPositionsByInstrument(string instrumentId);
        void AddPosition(Position position);
    }
}
