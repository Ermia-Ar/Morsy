namespace Morsy.Abstractions.Dtos;

public record SendOtpVoiceRequestDto(
    string PhoneNumber,
    string? GenerateCode
);