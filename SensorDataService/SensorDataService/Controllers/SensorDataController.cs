using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SensorDataService.Model;
using SensorDataService.Service;

namespace SensorDataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SensorDataController : ControllerBase
    {
        private readonly ILogger<SensorDataController> _logger;
        private DataService _dataService;

        public SensorDataController(ILogger<SensorDataController> logger, DataService dataService)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpGet("{sensorId}/{fromDate}/{toDate}")]
        public async Task<IEnumerable<DataPoint>> Get(string sensorId, DateTime fromDate, DateTime toDate)
        {
            return await _dataService.GetSensorData(sensorId, fromDate, toDate);
        }

        [HttpPost]
        public async Task<DataPoint?> Post(DataPoint datapoint)
        {
            return await _dataService.InsertSensorData(datapoint);
        }
    }
}
