/******************************************/
using ApiCustomer.Exceptions;
using ApiCustomer.Models;
using ApiCustomer.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;
/******************************************/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/******************************************/
// dependency injection ICustomerRepository
builder.Services.AddScoped<ICustomerRepository, CustomerSQLRepository>();
// configure the connection string
var connectionString = builder.Configuration.GetConnectionString("CustomerDB");
builder.Services.AddDbContext<ApiCustomerContext>(options => options.UseSqlServer(connectionString));
// configure serilog
builder.Host.UseSerilog((context, loggerConfig) =>
{
    loggerConfig.ReadFrom.Configuration(context.Configuration).WriteTo.Console();
});
/******************************************/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/******************************************/
// register the middleware
app.UseMiddleware(typeof(GlobalExceptionHandler));
/******************************************/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
