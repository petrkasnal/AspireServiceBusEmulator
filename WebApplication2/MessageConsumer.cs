using MassTransit;

namespace WebApplication2
{
    public class MessageConsumer : IConsumer<ConsumerMessage>
    {
        public async Task Consume(ConsumeContext<ConsumerMessage> context)
        {
            Console.WriteLine($"Received message: {context.Message.Message}");
        }
    }
}
