namespace EFSoft.Shared.ServiceBus.ServiceBus;

public class AzureServiceBus : IServiceBus
{
    public async Task SendToQueueAsync<T>(object message, string queueName) where T : class
    {
        await using var client = new ServiceBusClient(Settings.ConnnectionString);
        var sender = client.CreateSender(queueName);

        string jsonMessage = JsonSerializer.Serialize(message);
        var serviceBusMessage = new ServiceBusMessage(jsonMessage);

        await sender.SendMessageAsync(serviceBusMessage);
    }

    public async Task SendToTopicAsync<T>(object message, string topicName) where T : class
    {
        await using var client = new ServiceBusClient(Settings.ConnnectionString);
        var sender = client.CreateSender(topicName);

        string jsonMessage = JsonSerializer.Serialize(message);
        var serviceBusMessage = new ServiceBusMessage(jsonMessage);
        serviceBusMessage.ApplicationProperties.Add("messageType", typeof(T).Name);

        await sender.SendMessageAsync(serviceBusMessage);
    }
}
