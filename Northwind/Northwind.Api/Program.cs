using NLog;
using Northwind.Api.MiddleWares;
using Northwind.Application;
using Northwind.Core;
using Northwind.Core.Helpers.Logger;
using Northwind.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddDbContext<NorthwindContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("northwindContext"));
//});

LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));

builder.Services.AddInfrastructureConfiguration(builder.Configuration);
builder.Services.AddCoreModuleConfiguration();
builder.Services.AddApplicationModuleConfiguration(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILoggerManager>();

//app.ConfigureExceptionHandler(logger);
app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
