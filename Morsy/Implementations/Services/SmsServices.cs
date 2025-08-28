using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Morsy.Abstractions.Dtos;
using Morsy.Abstractions.Services;
using Morsy.Core.Exceptions;
using Morsy.Core.options;

namespace Morsy.Implementations.Services;

public class SmsServices : ISmsServices
{
    private readonly HttpClient _httpClient ;


    public SmsServices(HttpClient client, IConfiguration configuration,  IOptions<SmsServiceOptions> options)
    {
        client.BaseAddress = new Uri("https://api.limosms.com/api/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
       
        client.DefaultRequestHeaders.Add("ApiKey", options.Value.ApiKey);
        _httpClient = client;
    }
    
    public async Task<SendSmsResponseDto> SendSmsAsync(SendSmsRequestDto request, CancellationToken token = default)
    {
        var response = await _httpClient.PostAsJsonAsync("sendsms", request, token);
        var result = await response.Content.ReadAsStringAsync(token);
        var content = JsonSerializer.Deserialize<SendSmsResponseDto>(result);
        return content!;
    }

    public async Task<SendP2PResponseDto> SendP2PAsync(SendP2PRequestDto request, CancellationToken token = default)
    {
        var response = await _httpClient.PostAsJsonAsync("sendpeertopeersms", request, token);
        var result = await response.Content.ReadAsStringAsync(token);
        var content = JsonSerializer.Deserialize<SendP2PResponseDto>(result);
        return content!;
    }

    public async Task<SendPatternResponseDto> SendPatternAsync(SendPatternRequestDto request, CancellationToken token = default)
    {
        var response = await _httpClient.PostAsJsonAsync("sendpatternmessage", request, token);
        var result = await response.Content.ReadAsStringAsync(token);
        var content = JsonSerializer.Deserialize<SendPatternResponseDto>(result);
        return content!;
    }

    public async Task<GetStatusResponseDto> GetStatusAsync(GetStatusRequestDto request, CancellationToken token = default)
    {
        var response = await _httpClient.PostAsJsonAsync("getstatus", request, token);
        var result = await response.Content.ReadAsStringAsync(token);
        var content = JsonSerializer.Deserialize<GetStatusResponseDto>(result);
        return content!;
    }

    public async Task<GetCreditDto> GetCreditAsync(CancellationToken token = default)
    {
        var response = await _httpClient.PostAsync("getcurrentcredit", null, token);
        var result = await response.Content.ReadAsStringAsync(token);
        var content = JsonSerializer.Deserialize<GetCreditDto>(result);
        return content!;
    }
}