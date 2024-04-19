using AutoMapper;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcService.Models;
using GrpcService.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Diagnostics.Metrics;

namespace CRUDService.Services
{
    public class MyService: CRUDService.CRUDServiceBase
    {
        private readonly MeasurementDataAccess _measurementsService;
        private readonly IMapper _mapper;

        public MyService(IOptions<MongoDbConfiguration> settings, IMapper mapper)
        {
            _measurementsService = new MeasurementDataAccess(settings);
            _mapper = mapper;

        }
        public async override Task<Measurement> Create(Measurement request, ServerCallContext context)
        {
            Console.WriteLine("Create method called");
            try
            {
                await _measurementsService.CreateAsync(_mapper.Map<GrpcService.Models.Measurement>(request));
                var measurement = await _measurementsService.GetAsync(request.UID);

                return _mapper.Map<Measurement>(measurement);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating measurement: {ex.Message}");
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async override Task<Measurement> Read(MeasurementId request, ServerCallContext context)
        {
            Console.WriteLine("Read method called");
            try
            {
                var measurement = await _measurementsService.GetAsync(request.UID);

                return _mapper.Map<Measurement>(measurement);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading measurement: {ex.Message}");
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }

        public async override Task<Measurements> ReadAll(Empty request, ServerCallContext context)
        {
            Console.WriteLine("ReadAll method called");
            try
            {

                var measurements = await _measurementsService.GetAsync();
                var grpcMeasurements = _mapper.Map<List<Measurement>>(measurements);
                var grpcMeasurementsList = new Measurements();
                grpcMeasurementsList.MeasurementsData.AddRange((IEnumerable<Measurement>)grpcMeasurements);

                return grpcMeasurementsList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading all measurements: {ex.Message}");
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }
        }


        public override async Task<Measurement> Update(Measurement request, ServerCallContext context)
        {
            Console.WriteLine("Update method called");
            Console.WriteLine(request.ToString());
            try
            {
                var existingMeasurement = await _measurementsService.GetAsync(request.UID);
                if (existingMeasurement == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "There is no measurement in DB with thath UID."));
                }

                var mappedMeasurement = _mapper.Map<GrpcService.Models.Measurement>(request);
                mappedMeasurement.id= existingMeasurement.id;
                Console.WriteLine(mappedMeasurement.ToString());
                await _measurementsService.UpdateAsync(request.UID, mappedMeasurement);
                var measurement = await _measurementsService.GetAsync(request.UID);

                return _mapper.Map<Measurement>(measurement);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating measurement: {ex.Message}");
                throw new RpcException(new Status(StatusCode.Internal, ex.Message));
            }

        }

        public async override Task<MessageResponse> Delete(MeasurementId request, ServerCallContext context)
        {
            Console.WriteLine("Delete method called");
            try
            {
                var existingMeasurement = await _measurementsService.GetAsync(request.UID);
                if (existingMeasurement == null)
                {
                    return new MessageResponse { Message = $"Measurement with UID {request.UID} does not exist." };
                }
                await _measurementsService.RemoveAsync(request.UID);
                return new MessageResponse { Message = "Delete method completed successfully" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting measurement: {ex.Message}");
                return new MessageResponse { Message = $"Error deleting measurement: {ex.Message}" };
            }
        }

        public async override Task<AggregationResult> MinValue(AggregationParam request, ServerCallContext context)
        {
            Console.WriteLine("MinValue function called");

            var result = await _measurementsService.MinValue(request.StartTime, request.EndTime, request.DataField);

            return new AggregationResult { Result= $"Min value for {request.DataField} is {result}"};

        }

        public async override Task<AggregationResult> MaxValue(AggregationParam request, ServerCallContext context)
        {
            Console.WriteLine("MaxValue function called");

            var result = await _measurementsService.MaxValue(request.StartTime, request.EndTime, request.DataField);

            return new AggregationResult { Result = $"Max value for {request.DataField} is {result}" };

        }

        public async override Task<AggregationResult> AvgValue(AggregationParam request, ServerCallContext context)
        {
            Console.WriteLine("AvgValue function called");

            var result = await _measurementsService.AvgValue(request.StartTime, request.EndTime, request.DataField);

            return new AggregationResult { Result = $"Average value for {request.DataField} is {result}" };

        }

        public async override Task<AggregationResult> SumValue(AggregationParam request, ServerCallContext context)
        {
            Console.WriteLine("SumValue function called");

            var result = await _measurementsService.SumValue(request.StartTime, request.EndTime, request.DataField);

            return new AggregationResult { Result = $"Sum value for {request.DataField} is {result}" };

        }


    }
}
