using Azure.Messaging.ServiceBus;
using ServiceBus.Consumer;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var options = configuration.GetSection(ServiceBusSettings.Section);
        
        services.Configure<ServiceBusSettings>(options);

        services.AddSingleton((s) =>
        {
            return new ServiceBusClient(configuration.GetValue<string>("ServiceBus:ConnectionString"), new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            });
        });

        services.AddHostedService<Worker>();

    })
    .Build();

host.Run();
