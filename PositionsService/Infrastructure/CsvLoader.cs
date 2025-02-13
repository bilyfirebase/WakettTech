using CommonClasses.Enums;
using CommonClasses.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PositionsService.Infrastructure
{
    public class CsvLoader
    {
        public static List<Position> LoadPositionsFromCsv(string filePath)
        {
            var positions = new List<Position>();

            if (!File.Exists(filePath))
                return positions;

            using var reader = new StreamReader(filePath);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values.Length < 4) continue;

                positions.Add(new Position
                {
                    InstrumentId = values[0],
                    Quantity = decimal.Parse(values[1], CultureInfo.InvariantCulture),
                    InitialRate = decimal.Parse(values[2], CultureInfo.InvariantCulture),
                    Side = values[3].Trim().ToUpper() == "BUY" ? PositionSide.Buy : PositionSide.Sell
                });
            }

            return positions;
        }
    }
}
