using NLog;
using Northwind.Application;
using Northwind.Core;
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
builder.Services.AddApplicationModuleConfiguration();

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
