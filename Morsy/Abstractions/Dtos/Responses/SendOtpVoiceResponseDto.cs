namespace Morsy.Abstractions.Dtos.Responses;

public record SendOtpVoiceResponseDto(
    bool Success,
    string Message,
    string GenerateCode
    );