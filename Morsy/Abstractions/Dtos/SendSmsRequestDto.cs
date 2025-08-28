namespace Morsy.Abstractions.Dtos;

public record SendSmsRequestDto(
    string SenderNumber ,
    List<string> MobileNumber  ,
    string Message ,
    bool SendToBlocksNumber ,
    double? SendTimeSpan 
    );