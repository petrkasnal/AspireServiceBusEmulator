using Aspire.Hosting;
using Microsoft.AspNetCore.Builder;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var serviceBus = builder
    .AddAzureServiceBus("messaging")
    .RunAsEmulator(c => c.WithLifetime(ContainerLifetime.Persistent));

builder.AddProject<WebApplication2>("test")
    .WaitFor(serviceBus)
    .WithReference(serviceBus);
    //.WithReference(topic)
    //.WithReference(subs);

builder.Build().Run();
