using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using On_muhasebe_web.data.repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IGelirRepository), typeof(GelirRepository));
builder.Services.AddScoped(typeof(IGiderRepository), typeof(GiderRepository));
builder.Services.AddScoped(typeof(INetRepository), typeof(netRepository));
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
