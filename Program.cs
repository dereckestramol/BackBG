using BackendBG.Interfaces;
using BackendBG.Models;
using BackendBG.Scrutor;
using BackendBG.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(
         "MyAllowSpecificOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
        });
});

// Add services to the container.
builder.Services.AddDbContext<DatabaseBgContext>((options) => options.UseSqlServer(builder.Configuration.GetConnectionString("DefautlConnection")));
builder.Services.AddControllers();
builder.Services.AddServices();
var app = builder.Build();
app.UseCors("MyAllowSpecificOrigins");

// Configure the HTTP request pipeline.


app.UseAuthorization();

app.MapControllers();

app.Run();
