using NLog;
using Northwind.Application;
using Northwind.Core;
using Northwind.Core.Helpers.Logger;
using Northwind.Infrastructure;
using Northwind.MVC.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

LogManager.Setup().LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "nlog.config"));

builder.Services.AddInfrastructureConfiguration(builder.Configuration);
builder.Services.AddCoreModuleConfiguration();
builder.Services.AddApplicationModuleConfiguration(builder.Configuration);
builder.Services.AddEmailConfiguration(builder.Configuration);

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();

//app.ConfigureExceptionHandler(logger);
app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
