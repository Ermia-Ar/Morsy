using Microsoft.Extensions.DependencyInjection;
using Morsy.Abstractions.Services;
using Morsy.Core.options;
using Morsy.Implementations.Services;

namespace Morsy.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSmsService(this IServiceCollection services,
        Action<SmsServiceOptions> configureOptions)
    {
        services.Configure(configureOptions);

        services.AddHttpClient<ISmsServices, SmsServices>();

        return services;
    }
}