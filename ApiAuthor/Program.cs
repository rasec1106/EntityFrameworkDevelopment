using ApiAuthor.DbContexts;
using ApiAuthor.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/**************/
// Configuration for SQL connection
var cnn = builder.Configuration.GetConnectionString("ApiAuthorDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cnn));
// Configuration for Dependency Injection
builder.Services.AddScoped<IAuthorRepository, AuthorSqlRepository>();
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
