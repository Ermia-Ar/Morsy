namespace Morsy.Abstractions.Dtos.Requests;

public record SendSmsRequestDto(
    string SenderNumber ,
    List<string> MobileNumber  ,
    string Message ,
    bool SendToBlocksNumber ,
    double? SendTimeSpan 
    );