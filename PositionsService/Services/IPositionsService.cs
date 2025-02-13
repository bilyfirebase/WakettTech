using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonClasses.Models;

namespace PositionsService.Services
{
     public interface IPositionsService
     {
        List<Position> GetAllPositions();
        List<Position> GetPositionsByInstrument(string instrumentId);
        void AddPosition(Position position);
        void UpdatePositions(string instrumentId, decimal newRate);
     }
}
