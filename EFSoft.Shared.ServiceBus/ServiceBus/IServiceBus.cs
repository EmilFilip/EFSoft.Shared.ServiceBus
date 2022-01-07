namespace EFSoft.Shared.ServiceBus.ServiceBus;

public interface IServiceBus
{
    Task SendToQueueAsync<T>(object message, string queueName)
        where T : class;

    Task SendToTopicAsync<T>(object message, string topicName)
        where T : class;
}
