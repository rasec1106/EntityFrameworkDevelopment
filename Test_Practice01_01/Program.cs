/******************************************/
using Test_Practice01_01.Models;
using Test_Practice01_01.Repository;
using Microsoft.EntityFrameworkCore;
/******************************************/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/******************************************/
// dependency injection IProviderRepository
builder.Services.AddScoped<IProviderRepository, ProviderSQLRepository>();
// configure the connection string
var connectionString = builder.Configuration.GetConnectionString("ProviderDB");
builder.Services.AddDbContext<TestPractice01Context>(options => options.UseSqlServer(connectionString));
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
