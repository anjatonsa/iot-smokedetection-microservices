using GrpcService.Services;
using CRUDService.Services;
using GrpcService.Models;
using GrpcService.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.Configure<MongoDbConfiguration>(builder.Configuration.GetSection("MongoDbConfiguration"));
builder.Services.AddSingleton<MeasurementDataAccess>();
builder.Services.AddAutoMapper(typeof(MeasurementProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<MyService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
