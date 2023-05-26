using Microsoft.EntityFrameworkCore;
using System;
using Test_Practice02_01.DbContexts;
using Test_Practice02_01.Repository;

var builder = WebApplication.CreateBuilder(args);

/**************/
// Configuration for SQL connection
var cnn = builder.Configuration.GetConnectionString("Test02DB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cnn));
// Configuration for Dependency Injection
builder.Services.AddScoped<IShipRepository, ShipSqlRepository>();
/**************/

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
