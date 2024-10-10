using BackendBG.Scrutor;

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

builder.Services.AddControllers();
builder.Services.AddServices();

var app = builder.Build();
app.UseCors("MyAllowSpecificOrigins");

// Configure the HTTP request pipeline.


app.UseAuthorization();

app.MapControllers();

app.Run();
