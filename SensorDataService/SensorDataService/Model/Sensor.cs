using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataService.Model
{
    public class Sensor
    {
        [PrimaryKey]
        public string? Id { get; set; }

        public double UpperLimit { get; set; }

        public double LowerLimit { get; set; }
    }
}
