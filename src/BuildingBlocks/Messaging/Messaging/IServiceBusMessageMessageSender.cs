namespace Messaging;

public interface IServiceBusMessageSender
{
    void Send<T>(T message)
       where T : class, IServiceBusMessage;
}

