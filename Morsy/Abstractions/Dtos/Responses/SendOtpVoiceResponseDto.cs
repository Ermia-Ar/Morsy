namespace Morsy.Abstractions.Dtos;

public record SendOtpVoiceResponseDto(
    bool Success,
    string Message,
    string GenerateCode
    );