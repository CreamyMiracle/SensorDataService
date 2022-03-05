using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SensorDataService.Controllers;
using SensorDataService.Hubs;
using SensorDataService.Model;
using SensorDataService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SensorDataService.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly ILogger<SensorDataController> _logger;
        private DataService _dataService;
        private readonly IHubContext<SensorsHub> _sensorsHub;

        public SensorsController(ILogger<SensorDataController> logger, DataService dataService, IHubContext<SensorsHub> sensorsHub)
        {
            _logger = logger;
            _dataService = dataService;
            _sensorsHub = sensorsHub;
        }

        [HttpGet]
        public async Task<IEnumerable<Sensor>> Get()
        {
            return await _dataService.GetSensors();
        }

        [HttpPut]
        public async Task<Sensor?> Put(Sensor sensor)
        {
            return await _dataService.PutSensor(sensor);
        }
    }
}
