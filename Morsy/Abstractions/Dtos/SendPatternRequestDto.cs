namespace Morsy.Abstractions.Dtos;

public class SendPatternRequestDto(
    long OtpId, 
    string MobileNumber ,
    List<object> ReplaceToken
    );