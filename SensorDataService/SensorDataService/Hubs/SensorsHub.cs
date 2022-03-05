using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SensorDataService.Hubs
{
    public class SensorsHub : Hub
    {
        public SensorsHub(ILogger<SensorsHub> logger)
        {
            _logger = logger;
        }

        #region Private Fields
        private readonly ILogger<SensorsHub> _logger;
        #endregion
    }
}
