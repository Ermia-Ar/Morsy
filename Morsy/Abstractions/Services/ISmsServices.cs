using Morsy.Abstractions.Dtos;

namespace Morsy.Abstractions.Services;

public interface ISmsServices
{
    Task<SendSmsResponseDto> SendSmsAsync(SendSmsRequestDto request, CancellationToken token = default);
    
    Task<SendP2PResponseDto> SendP2PAsync(SendP2PRequestDto request, CancellationToken token = default);
    
    Task<SendPatternResponseDto> SendPatternAsync(SendPatternRequestDto request, CancellationToken token = default);
    
    Task<GetStatusResponseDto> GetStatusAsync(GetStatusRequestDto request, CancellationToken token = default);
    
    Task<GetCreditDto> GetCreditAsync(CancellationToken token = default);
}