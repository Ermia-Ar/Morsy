namespace Morsy.Abstractions.Dtos;

public record SendPatternRequestDto(
    long OtpId,
    string MobileNumber,
    List<object> ReplaceToken
);