
using Album.Service;
using Microsoft.Extensions.Options;
using Album.Business;
using MusicWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT");
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile($"appsettings.{(string.IsNullOrEmpty(environment) ? "Production" : environment)}.json", true);

builder.Services.Configure<ServiceEndpointOptions>(builder.Configuration);
var endpointOptions = builder.Configuration.Get<ServiceEndpointOptions>();

foreach (var endpoint in endpointOptions.ApiEndpoints)
{
    builder.Services.AddHttpClient(endpoint.Name, o =>
    {
        o.BaseAddress = new Uri(endpoint.Url);
    });
}
builder.Services.AddServiceConfiguration();
builder.Services.AddBusinessConfiguration();
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Albums}/{action=Index}/{id?}");

app.Run();
