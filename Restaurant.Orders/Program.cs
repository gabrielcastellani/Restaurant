using Restaurant.Orders.Domain.Orders.Services;
using Restaurant.Orders.Infrastructure.Repositories;
using Restaurant.Orders.Infrastructure.Repositories.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cnf =>
    cnf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Domain
builder.Services.AddSingleton<IOrdersService, OrdersService>();

// Infrastructure
builder.Services.AddSingleton<IOrdersRepository, OrdersRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
