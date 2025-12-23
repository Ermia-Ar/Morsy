namespace Morsy.Abstractions.Dtos.Requests;

public record SendPatternRequestDto(
    long OtpId,
    string MobileNumber,
    List<object> ReplaceToken
);