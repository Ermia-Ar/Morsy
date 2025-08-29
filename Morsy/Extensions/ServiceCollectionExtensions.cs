using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Morsy.Abstractions.Services;
using Morsy.Common.Exceptions;
using Morsy.Common.options;
using Morsy.Implementations.Services;

namespace Morsy.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSmsService(this IServiceCollection services,
        Action<SmsServiceOptions> configureOptions,  ConfigurationManager configuration)
    {
        services.Configure(configureOptions);
        
        services.AddClient();

        
        return services;
    }


    private static IServiceCollection AddClient(this IServiceCollection services)
    {
        services.AddHttpClient<ISmsServices, SmsServices>("LimoSms", (sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<SmsServiceOptions>>().Value;
            client.BaseAddress = new Uri(SmsSetting.BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            
            if (string.IsNullOrWhiteSpace(options.ApiKey))
                throw new NullApiTokenException();

            client.DefaultRequestHeaders.Add("ApiKey", options.ApiKey);
        });
        return services;
    }
}