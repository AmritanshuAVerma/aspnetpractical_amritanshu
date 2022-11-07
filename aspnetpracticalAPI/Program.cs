using aspnetpracticalAPI.Middleware;
using Microsoft.AspNetCore.HttpLogging;
using Album.Data;
using Album.Business;
using AlbumAPI.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddContextConfiguration(builder.Configuration);
builder.Services.AddDataConfiguration();
builder.Services.AddBusinessConfiguration();
builder.Services.AddLogging(config =>
{
    config.ClearProviders();
    config.AddConsole();
    config.AddFile(builder.Configuration);
});

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("MyResponseHeader");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();
app.UseHttpLogging();
app.UseGlobalExceptionHandler(app.Logger);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRequestLogger();

app.Run();