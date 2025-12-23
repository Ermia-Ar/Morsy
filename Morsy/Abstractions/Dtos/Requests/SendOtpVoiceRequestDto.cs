namespace Morsy.Abstractions.Dtos.Requests;

public record SendOtpVoiceRequestDto(
    string PhoneNumber,
    string? GenerateCode
);