using CarWorkshop;
using CarWorkshop.Repositories;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data.Common;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using FluentMigrator.Runner.Initialization;
using System;
using System.Reflection;
using System.Data;

[assembly: ApiController]
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<UsersRepository>();
builder.Services.AddSingleton<CarsRepository>();
builder.Services.AddSingleton<OrdersRepository>();


builder.Services.AddTransient<IDbConnection>(s => new NpgsqlConnection("Server=localhost:5431;Database=production;User Id=admin;Password=admin;"));
builder.Services
    .AddFluentMigratorCore().ConfigureRunner(rb =>
        rb.AddPostgres().
            WithGlobalConnectionString("Server=localhost:5431;Database=production;User Id=admin;Password=admin;")
            .ScanIn(Assembly.GetExecutingAssembly()).For
            .Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole())
    .BuildServiceProvider(false);

var app = builder.Build(); ;
using var serviceprovider = app.Services.CreateScope();
var services = serviceprovider.ServiceProvider;
var runner = services.GetRequiredService<IMigrationRunner>();
runner.MigrateUp();


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