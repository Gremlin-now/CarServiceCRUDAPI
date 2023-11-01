using CarServiceCRUDAPI.Migrations;
using CarServiceCRUDAPI.Models;
using CarServiceCRUDAPI.Repositories;
using FluentMigrator.Runner;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBaseRepository<Car>, CarRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IBaseRepository<Client>, ClientRepository>();

builder.Services.AddLogging(c => c.AddFluentMigratorConsole())
        .AddFluentMigratorCore()
        .ConfigureRunner(c => c 
            .AddPostgres()
            .WithGlobalConnectionString(builder.Configuration.GetConnectionString("PostgreSQL"))
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        .BuildServiceProvider(false);

var app = builder.Build();
app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod());
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
