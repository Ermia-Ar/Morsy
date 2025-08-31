namespace Morsy.Implementations.Services;

public class SmsServices : ISmsServices
{
    private readonly HttpClient _httpClient;

    public SmsServices(HttpClient httpClient, IOptions<SmsServiceOptions> options)
    {
        var apiKey = options.Value.ApiKey ?? throw new ArgumentNullException(nameof(options));

        if (string.IsNullOrWhiteSpace(SmsSetting.BaseUrl))
            throw new ArgumentException("BaseUrl is not configured in SmsServiceOptions.");

        if (string.IsNullOrWhiteSpace(apiKey))
            throw new NullApiTokenException();

        httpClient.BaseAddress = new Uri(SmsSetting.BaseUrl);
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add("ApiKey", apiKey);

        _httpClient = httpClient;
    }
    
    public async Task<SendSmsResponseDto> SendSmsAsync(string senderNumber, List<string> mobileNumber, string message, bool sendToBlocksNumber, double? sendTimeSpan,
        CancellationToken token = default)
    {
        var request = new SendSmsRequestDto(senderNumber,
            mobileNumber, message, sendToBlocksNumber, sendTimeSpan);
        
        var response = await _httpClient.PostAsJsonAsync("sendsms", request, token);
        var result = await response.Content.ReadAsStringAsync(token);
        var content = JsonSerializer.Deserialize<SendSmsResponseDto>(result);
        return content!;
    }

    public async Task<SendP2PResponseDto> SendP2PAsync(string senderNumber, List<string> mobileNumber, List<string> message, bool sendToBlocksNumber, double? sendAfter,
        CancellationToken token = default)
    {
        var request = new SendP2PRequestDto(senderNumber,
            mobileNumber, message, sendToBlocksNumber, sendAfter);
        
        var response = await _httpClient.PostAsJsonAsync("sendpeertopeersms", request, token);
        var result = await response.Content.ReadAsStringAsync(token);
        var content = JsonSerializer.Deserialize<SendP2PResponseDto>(result);
        return content!;
    }

    public async Task<SendPatternResponseDto> SendPatternAsync(long otpId, string mobileNumber, List<object> replaceToken, CancellationToken token = default)
    {
         var request = new SendPatternRequestDto(otpId, mobileNumber, replaceToken);
        
        var response = await _httpClient.PostAsJsonAsync("sendpatternmessage", request, token);
        var result = await response.Content.ReadAsStringAsync(token);
        var content = JsonSerializer.Deserialize<SendPatternResponseDto>(result);
        return content!;
    }

    public async Task<GetStatusResponseDto> GetStatusAsync(List<string> messageIds, CancellationToken token = default)
    {
        var request = new GetStatusRequestDto(messageIds);
        
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