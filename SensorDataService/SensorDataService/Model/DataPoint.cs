using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace SensorDataService.Model
{
    public class DataPoint
    {
        public string? SensorId { get; set; }

        public double Value { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
