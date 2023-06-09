using ApiCategory.DbContexts;
using ApiCategory.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

/**************/
// Configuration for SQL connection
var cnn = builder.Configuration.GetConnectionString("CategoryDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cnn));
// Configuration for Dependency Injection
builder.Services.AddScoped<ICategoryRepository, CategorySQLRepository>();
// Cors configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            // dont forget to add http or https
            policy.WithOrigins("http://localhost:4200") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
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

/**************/
// Extra line for CORS after build
app.UseCors("MyAllowedOrigins");
/**************/

app.Run();
