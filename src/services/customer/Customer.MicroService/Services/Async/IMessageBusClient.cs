namespace Customer.MicroService.Services.Async;

public interface IMessageBusClient {
    Task<bool> PublishMessage(string exchangeName, string message);
}
