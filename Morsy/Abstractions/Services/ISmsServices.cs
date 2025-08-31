namespace Morsy.Abstractions.Services;

public interface ISmsServices
{
    Task<SendSmsResponseDto> SendSmsAsync( 
        string senderNumber ,
        List<string> mobileNumber  ,
        string message ,
        bool sendToBlocksNumber ,
        double? sendTimeSpan , 
        CancellationToken token = default);
    
    Task<SendP2PResponseDto> SendP2PAsync(
        string senderNumber ,
        List<string> mobileNumber,
        List<string> message,
        bool sendToBlocksNumber,
        double? sendTimeSpan,
        CancellationToken token = default);
    
    Task<SendPatternResponseDto> SendPatternAsync(
        long otpId, 
        string mobileNumber ,
        List<object> replaceToken, 
        CancellationToken token = default);
    
    Task<GetStatusResponseDto> GetStatusAsync(
        List<string> messageIds,
        CancellationToken token = default);
    
    Task<GetCreditDto> GetCreditAsync(
        CancellationToken token = default);
}