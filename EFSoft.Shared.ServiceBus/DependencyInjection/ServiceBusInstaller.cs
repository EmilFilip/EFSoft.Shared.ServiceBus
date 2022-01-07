namespace EFSoft.Shared.ServiceBus.DependencyInjection;

[ExcludeFromCodeCoverage]
public static class ServiceBusInstaller
{
    /// <summary>
    /// Registers ServiceBus as singleton
    /// </summary>
    /// <param name="services">The service collection that the ServiceBus should be added to</param>
    public static IServiceCollection AddServiceBus(
        this IServiceCollection services)
    {

        return services.AddSingleton<IServiceBus, AzureServiceBus>();
    }
}