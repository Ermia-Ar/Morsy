using Morsy.Abstractions.Dtos.Requests;
using Morsy.Abstractions.Dtos.Responses;

namespace Morsy.Implementations.Services;

public class SmsServices : ISmsServices
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public SmsServices(HttpClient httpClient, IOptions<SmsServiceOptions> options)
    {
        var apiKey = options.Value.ApiKey ?? throw new ArgumentNullException(nameof(options));

        if (string.IsNullOrWhiteSpace(apiKey))
            throw new NullApiTokenException();
        httpClient.BaseAddress = new Uri(SmsSetting.BaseUrl);
        _httpClient = httpClient;
        _apiKey = apiKey;
    }
    
    public async Task<SendSmsResponseDto> SendSmsAsync(string senderNumber, List<string> mobileNumbers, string message, bool sendToBlocksNumber, double? sendTimeSpan,
        CancellationToken cancellationToken = default)
    {
        var requestDto = new SendSmsRequestDto(senderNumber,
            mobileNumbers, message, sendToBlocksNumber, sendTimeSpan);
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "sendsms")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<SendSmsResponseDto>(result);
        return content!;
    }

    public async Task<SendP2PResponseDto> SendP2PAsync(string senderNumber, List<string> mobileNumbers, List<string> messages, bool sendToBlocksNumber, double? sendAfter,
        CancellationToken cancellationToken = default)
    {
        var requestDto = new SendP2PRequestDto(senderNumber,
            mobileNumbers, messages, sendToBlocksNumber, sendAfter);
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "sendpeertopeersms")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<SendP2PResponseDto>(result);
        return content!;
    }

    public async Task<SendPatternResponseDto> SendPatternAsync(long otpId, string mobileNumber, List<object> replaceTokens, CancellationToken cancellationToken = default)
    {
         var requestDto = new SendPatternRequestDto(otpId, mobileNumber, replaceTokens);
         
         var jsonRequest = JsonSerializer.Serialize(requestDto);

         var request = new HttpRequestMessage(HttpMethod.Post, "sendpatternmessage")
         {
             Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
         };
        
         request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<SendPatternResponseDto>(result);
        return content!;
    }

    public async Task<GetStatusResponseDto> GetStatusAsync(List<string> messageIds, CancellationToken cancellationToken = default)
    {
        var requestDto = new GetStatusRequestDto(messageIds);
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "getstatus")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<GetStatusResponseDto>(result);
        return content;
    }

    public async Task<GetCreditResponseDto> GetCreditAsync(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "getcurrentcredit");
        
        request.Headers.Add("ApiKey", _apiKey);
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<GetCreditResponseDto>(result);
        return content;
    }

    public async Task<SendFromFromResponseDto> SendFromFromAsync(string senderNumber, List<string> mobileNumberS, string message, string apiKey, CancellationToken cancellationToken = default)
    {
        var requestDto = new SendFromFromRequestDto(senderNumber, mobileNumberS, message, apiKey);
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "SendSmsFromForm")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<SendFromFromResponseDto>(result);
        return content;
    }

    public async Task<SendCodeResponseDto> SendCodeAsync(string mobileNumber, string footer, CancellationToken cancellationToken = default)
    {
        var requestDto = new SendCodeRequestDto(mobileNumber, footer);
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "sendcode")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<SendCodeResponseDto>(result);
        return content;
    }

    public async Task<CheckCodeResponseDto> CheckCodeAsync(string mobileNumber, string code, CancellationToken cancellationToken = default)
    {
        var requestDto = new CheckCodeRequestDto(mobileNumber, code);
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "checkcode")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<CheckCodeResponseDto>(result);
        return content;
    }

    public async Task<GetReceivedMessageResponseDto> GetReceivedMessageAsync(string number, int pageSize, int pageNumber, CancellationToken cancellationToken = default)
    {
        var requestDto = new GetReceivedMessageRequestDto(number, pageSize, pageNumber); 
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "getreceivedmessage")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<GetReceivedMessageResponseDto>(result);
        return content;
    }

    public async Task<SendOtpVoiceResponseDto> SendOtpVoiceAsync(string mobileNumber, string? generationCode, CancellationToken cancellationToken = default)
    {
        var requestDto = new SendOtpVoiceRequestDto(mobileNumber, generationCode);
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "SendOTPVoice")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<SendOtpVoiceResponseDto>(result);
        return content;
    }

    public async Task<CancelUserOneMessageResponseDto> CancelUserOneMessageAsync(long messageId, CancellationToken cancellationToken = default)
    {
        var requestDto = new CancelUserOneMessageRequestDto(messageId);
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "CancelUserOneMessage")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<CancelUserOneMessageResponseDto >(result);
        return content;
    }

    public async Task<SendVoiceResponseDto> SendVoiceAsync(long voiceId, List<string> mobileNumbers, short maxTry, int minuteBetweenTries,
        double startTimeSpan, double endTimeSpan, bool hasVote, CancellationToken cancellationToken = default)
    {
        var requestDto = new SendVoiceRequestDto(voiceId, mobileNumbers, maxTry, minuteBetweenTries, startTimeSpan, endTimeSpan, hasVote);
        
        var jsonRequest = JsonSerializer.Serialize(requestDto);

        var request = new HttpRequestMessage(HttpMethod.Post, "sendvoice")
        {
            Content = new StringContent(jsonRequest, Encoding.UTF8, "application/json")
        };
        
        request.Headers.Add("ApiKey", _apiKey);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        var result = await response.Content.ReadAsStringAsync(cancellationToken);
        var content = JsonHelper.JsonDeserialize<SendVoiceResponseDto >(result);
        return content;
    }
}