using SensorDataService.Model;
using SensorDataService.Service;
using SQLite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

SQLiteAsyncConnection con = new SQLiteAsyncConnection(@".\sensordata.db");
con.CreateTableAsync<DataPoint>();
con.CreateTableAsync<Sensor>();

builder.Services.AddControllers();
builder.Services.AddSingleton<DataService>(new DataService(con));
builder.Services.AddSingleton<SQLiteAsyncConnection>(con);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
