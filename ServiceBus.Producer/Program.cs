using Azure.Messaging.ServiceBus;
using ServiceBus.Producer.Models;
using ServiceBus.Producer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serviceBusSettings = builder.Configuration.GetSection(ServiceBusSettings.Section);
builder.Services.Configure<ServiceBusSettings>(serviceBusSettings);

builder.Services.AddSingleton<IMessagePublisher, MessagePublisher>();

builder.Services.AddSingleton((s) =>
{
    return new ServiceBusClient(builder.Configuration.GetValue<string>("ServiceBus:ConnectionString"));
});

builder.Services.AddSingleton((s) =>
{
    return new ServiceBusClient(builder.Configuration.GetValue<string>("ServiceBus:ConnectionString"));
});


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