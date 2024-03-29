using Microsoft.EntityFrameworkCore;
using MyBooks.Data;
using MyBooks.Service;
using Serilog.Events;
using Serilog;
using Serilog.Formatting.Compact;
using Microsoft.Extensions.Logging;
using Microsoft.Owin.Logging;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddTransient<BookService>();
builder.Services.AddTransient<AuthorsService>();
builder.Services.AddTransient<PublisherService>();
//builder.Services.AddApiVersioning();
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// Configure Serilog
Serilog.Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

builder.Host.UseSerilog();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Exception Handling
//app.ConfigureCustomExceptionHandler(LoggerFactory);
app.UseExceptionHandler();
app.MapControllers();

app.Run();
