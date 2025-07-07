using MassTransit;
using WebApplication2;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddAzureServiceBusClient(connectionName: "messaging");

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageConsumer>();
   
    x.UsingAzureServiceBus((context, cfg) =>
    {
        var connectionString = builder.Configuration.GetConnectionString("messaging");
 
        cfg.Host(connectionString);

        cfg.ConfigureEndpoints(context);
    });
});

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
