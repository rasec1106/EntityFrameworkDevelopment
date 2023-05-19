/******************************************/
using ApiStorage;
using ApiStorage.Models;
using ApiStorage.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
/******************************************/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/******************************************/
// Register automapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper); // using singleton patron ... to let it live in memory!!!
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // this line is needed... read the documentation
// dependency injection IStorageRepository
builder.Services.AddScoped<IStorageRepository, StorageSQLRepository>();
// configure the connection string
var connectionString = builder.Configuration.GetConnectionString("StorageDB");
builder.Services.AddDbContext<ApiStorageContext>(options => options.UseSqlServer(connectionString));
/******************************************/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
