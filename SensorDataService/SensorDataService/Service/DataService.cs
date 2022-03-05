using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SensorDataService.Model;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace SensorDataService.Service
{
    public class DataService
    {
        private readonly SQLiteAsyncConnection db_con;

        public DataService(SQLiteAsyncConnection con)
        {
            db_con = con;
        }

        public async Task<IEnumerable<Sensor>> GetSensors()
        {
            return await db_con.GetAllWithChildrenAsync<Sensor>();
        }

        public async Task<Sensor?> PutSensor(Sensor sensor)
        {
            return await db_con.UpdateAsync(sensor) == 1 ? sensor : null;
        }

        public async Task<IEnumerable<DataPoint>> GetSensorData(string sensorId, DateTime fromDate, DateTime toDate)
        {
            return await db_con.GetAllWithChildrenAsync<DataPoint>(dp => dp.SensorId == sensorId && dp.Timestamp > fromDate && dp.Timestamp <= toDate);
        }

        public async Task<DataPoint?> InsertSensorData(DataPoint datapoint)
        {
            try
            {
                await db_con.GetAsync<Sensor>(datapoint.SensorId);
            }
            catch (Exception ex)
            {
                await db_con.InsertAsync(new Sensor() { Id = datapoint.SensorId });
            }

            return await db_con.InsertAsync(datapoint) == 1 ? datapoint : null;
        }

        #region Private Methods

        #endregion
    }
}
