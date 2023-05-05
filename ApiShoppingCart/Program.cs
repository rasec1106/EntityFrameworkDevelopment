/**************/
using Microsoft.EntityFrameworkCore;
using ApiShoppingCart.DbContexts;
using ApiShoppingCart.Repository;
/**************/

var builder = WebApplication.CreateBuilder(args);

/**************/
// Configuration for SQL connection
var cnn = builder.Configuration.GetConnectionString("CartDB");
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(cnn));
// Configuration for Dependency Injection
builder.Services.AddScoped<ICartRepository, CartSqlRepository>();
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
