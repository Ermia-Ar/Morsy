namespace Morsy.ConfigureServices;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSmsService(this IServiceCollection services,
        Action<SmsServiceOptions> configureOptions)
    {
        services.Configure(configureOptions);
        
        services.AddClient();

        
        return services;
    }


    private static IServiceCollection AddClient(this IServiceCollection services)
    {
        services.AddHttpClient<ISmsServices, SmsServices>();
        return services;
    }
}