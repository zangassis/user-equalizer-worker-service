using UserEqualizerWorkerService;
using UserEqualizerWorkerService.Data;
using UserEqualizerWorkerService.Data.Api;
using UserEqualizerWorkerService.Services.v1;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddTransient<UserDbContext>();
        services.AddDbContext<UserDbContext>();
        services.AddTransient<UserEqualizerService>();
        services.AddHttpClient<PlaceHolderClient>(client =>
        {
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
        });
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
