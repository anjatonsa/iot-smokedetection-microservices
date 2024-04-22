using AutoMapper;
using GrpcService.DbContext;
using GrpcService.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GrpcService.Services
{
    public class MeasurementDataAccess
    {
        private readonly IMongoCollection<Measurement> _measurementsCollection;

        public MeasurementDataAccess(IOptions<MongoDbConfiguration> settings)
        {
            var dbContext = new MongoDbContext(settings);
            _measurementsCollection = dbContext._measurementsCollection;
        }

        public async Task<List<Measurement>> GetAsync() =>
            await _measurementsCollection.Find(_ => true).Limit(15).ToListAsync();

        public async Task<Measurement?> GetAsync(int id) =>
            await _measurementsCollection.Find(x => x.UID == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Measurement newMeasurment) =>
            await _measurementsCollection.InsertOneAsync(newMeasurment);

        public async Task UpdateAsync(int id, Measurement updatedMeasurement) =>
            await _measurementsCollection.ReplaceOneAsync(x => x.UID == id, updatedMeasurement);

        public async Task RemoveAsync(int id) =>
            await _measurementsCollection.DeleteOneAsync(x => x.UID == id);

        public async Task<double> MinValue(Google.Protobuf.WellKnownTypes.Timestamp startDateTime, Google.Protobuf.WellKnownTypes.Timestamp endDateTime, string dataField)
        {
            var filter = Builders<Measurement>.Filter.And(
                Builders<Measurement>.Filter.Gte(m => m.Timestamp, startDateTime.ToDateTime()),
                Builders<Measurement>.Filter.Lte(m => m.Timestamp, endDateTime.ToDateTime()));
            var timerange = await _measurementsCollection.Find(filter).ToListAsync();
            double minValue=0;
            switch (dataField)
            {
                case "Temperature":
                    minValue = timerange
                        .Select(doc => doc.Temperature)
                        .Min();
                    break;

                case "Humidity":
                    minValue = timerange
                        .Select(doc => doc.Humidity)
                        .Min();
                    break;

                case "TVOC":
                    minValue = timerange
                        .Select(doc => doc.TVOC)
                        .Min();
                    break;

                case "eCO2":
                    minValue = timerange
                        .Select(doc => doc.eCO2)
                        .Min();
                    break;

                case "Raw H2":
                    minValue = timerange
                        .Select(doc => doc.RawH2)
                        .Min();
                    break;

                case "Raw Ethanol":
                    minValue = timerange
                        .Select(doc => doc.RawEthanol)
                        .Min();
                    break;

                case "Pressure":
                    minValue = timerange
                        .Select(doc => doc.Pressure)
                        .Min();
                    break;

                case "PM1.0":
                    minValue = timerange
                        .Select(doc => doc.PM10)
                        .Min();
                    break;

                case "PM2.5":
                    minValue = timerange
                        .Select(doc => doc.PM25)
                        .Min();
                    break;

                case "NC0.5":
                    minValue = timerange
                        .Select(doc => doc.NC05)
                        .Min();
                    break;

                case "NC1.0":
                    minValue = timerange
                        .Select(doc => doc.NC10)
                        .Min();
                    break;

                case "NC2.5":
                    minValue = timerange
                        .Select(doc => doc.NC25)
                        .Min();
                    break;

                default:
                    throw new ArgumentException("Invalid dataField value");
            }

            return minValue;
        }


        public async Task<double> MaxValue(Google.Protobuf.WellKnownTypes.Timestamp startDateTime, Google.Protobuf.WellKnownTypes.Timestamp endDateTime, string dataField)
        {
            var filter = Builders<Measurement>.Filter.And(
                Builders<Measurement>.Filter.Gte(m => m.Timestamp, startDateTime.ToDateTime()),
                Builders<Measurement>.Filter.Lte(m => m.Timestamp, endDateTime.ToDateTime()));
            var timerange = await _measurementsCollection.Find(filter).ToListAsync();
            double maxValue = 0;
            switch (dataField)
            {
                case "Temperature":
                    maxValue = timerange
                        .Select(doc => doc.Temperature)
                        .Max();
                    break;

                case "Humidity":
                    maxValue = timerange
                        .Select(doc => doc.Humidity)
                        .Max();

                    break;

                case "TVOC":
                    maxValue = timerange
                        .Select(doc => doc.TVOC)
                        .Max();

                    break;

                case "eCO2":
                    maxValue = timerange
                        .Select(doc => doc.eCO2)
                        .Max();

                    break;

                case "Raw H2":
                    maxValue = timerange
                        .Select(doc => doc.RawH2)
                        .Max();

                    break;

                case "Raw Ethanol":
                    maxValue = timerange
                        .Select(doc => doc.RawEthanol)
                        .Max();

                    break;

                case "Pressure":
                    maxValue = timerange
                        .Select(doc => doc.Pressure)
                        .Max();

                    break;

                case "PM1.0":
                    maxValue = timerange
                        .Select(doc => doc.PM10)
                        .Max();

                    break;

                case "PM2.5":
                    maxValue = timerange
                        .Select(doc => doc.PM25)
                        .Max();

                    break;

                case "NC0.5":
                    maxValue = timerange
                        .Select(doc => doc.NC05)
                        .Max();

                    break;

                case "NC1.0":
                    maxValue = timerange
                        .Select(doc => doc.NC10)
                        .Max();

                    break;

                case "NC2.5":
                    maxValue = timerange
                        .Select(doc => doc.NC25)
                        .Max();

                    break;

                default:
                    throw new ArgumentException("Invalid dataField value");
            }



            return maxValue;
        }


        public async Task<double> AvgValue(Google.Protobuf.WellKnownTypes.Timestamp startDateTime, Google.Protobuf.WellKnownTypes.Timestamp endDateTime, string dataField)
        {
            var filter = Builders<Measurement>.Filter.And(
                Builders<Measurement>.Filter.Gte(m => m.Timestamp, startDateTime.ToDateTime()),
                Builders<Measurement>.Filter.Lte(m => m.Timestamp, endDateTime.ToDateTime()));
            var timerange = await _measurementsCollection.Find(filter).ToListAsync();
            double avgValue = 0;
            switch (dataField)
            {
                case "Temperature":
                    avgValue = timerange
                        .Select(doc => doc.Temperature)
                        .Average();
                    break;

                case "Humidity":
                    avgValue = timerange
                        .Select(doc => doc.Humidity)
                        .Average();

                    break;

                case "TVOC":
                    avgValue = timerange
                        .Select(doc => doc.TVOC)
                        .Average();

                    break;

                case "eCO2":
                    avgValue = timerange
                        .Select(doc => doc.eCO2)
                        .Average();

                    break;

                case "Raw H2":
                    avgValue = timerange
                        .Select(doc => doc.RawH2)
                        .Average();

                    break;

                case "Raw Ethanol":
                    avgValue = timerange
                        .Select(doc => doc.RawEthanol)
                        .Average();

                    break;

                case "Pressure":
                    avgValue = timerange
                        .Select(doc => doc.Pressure)
                        .Average();

                    break;

                case "PM1.0":
                    avgValue = timerange
                        .Select(doc => doc.PM10)
                        .Average();

                    break;

                case "PM2.5":
                    avgValue = timerange
                        .Select(doc => doc.PM25)
                        .Average();

                    break;

                case "NC0.5":
                    avgValue = timerange
                        .Select(doc => doc.NC05)
                        .Average();

                    break;

                case "NC1.0":
                    avgValue = timerange
                        .Select(doc => doc.NC10)
                        .Average();

                    break;

                case "NC2.5":
                    avgValue = timerange
                        .Select(doc => doc.NC25)
                        .Average();

                    break;

                default:
                    throw new ArgumentException("Invalid dataField value");
            }



            return avgValue;
        }
       

        public async Task<double> SumValue(Google.Protobuf.WellKnownTypes.Timestamp startDateTime, Google.Protobuf.WellKnownTypes.Timestamp endDateTime, string dataField)
        {
            var filter = Builders<Measurement>.Filter.And(
                Builders<Measurement>.Filter.Gte(m => m.Timestamp, startDateTime.ToDateTime()),
                Builders<Measurement>.Filter.Lte(m => m.Timestamp, endDateTime.ToDateTime()));
            var timerange = await _measurementsCollection.Find(filter).ToListAsync();
            double sumValue = 0;
            switch (dataField)
            {
                case "Temperature":
                    sumValue = timerange
                        .Select(doc => doc.Temperature)
                        .Sum();
                    break;

                case "Humidity":
                    sumValue = timerange
                        .Select(doc => doc.Humidity)
                        .Sum();

                    break;

                case "TVOC":
                    sumValue = timerange
                        .Select(doc => doc.TVOC)
                        .Sum();

                    break;

                case "eCO2":
                    sumValue = timerange
                        .Select(doc => doc.eCO2)
                        .Sum();

                    break;

                case "Raw H2":
                    sumValue = timerange
                        .Select(doc => doc.RawH2)
                        .Sum();

                    break;

                case "Raw Ethanol":
                    sumValue = timerange
                        .Select(doc => doc.RawEthanol)
                        .Sum();

                    break;

                case "Pressure":
                    sumValue = timerange
                        .Select(doc => doc.Pressure)
                        .Sum();

                    break;

                case "PM1.0":
                    sumValue = timerange
                        .Select(doc => doc.PM10)
                        .Sum();

                    break;

                case "PM2.5":
                    sumValue = timerange
                        .Select(doc => doc.PM25)
                        .Sum();

                    break;

                case "NC0.5":
                    sumValue = timerange
                        .Select(doc => doc.NC05)
                        .Sum();

                    break;

                case "NC1.0":
                    sumValue = timerange
                        .Select(doc => doc.NC10)
                        .Sum();

                    break;

                case "NC2.5":
                    sumValue = timerange
                        .Select(doc => doc.NC25)
                        .Sum();

                    break;

                default:
                    throw new ArgumentException("Invalid dataField value");
            }


            return sumValue;
        }

    }
}
 