using System.Net.Http.Json;
using System.Text.Json;
using Morsy.Abstractions.Dtos;
using Morsy.Abstractions.Services;

namespace Morsy.Implementations.Services;

public class SmsServices(IHttpClientFactory httpClientFactory) : ISmsServices
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("LimoSms");


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