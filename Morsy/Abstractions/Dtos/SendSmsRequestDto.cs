namespace Morsy.Abstractions.Dtos;

public class SendSmsRequestDto(
    string SenderNumber ,
    List<string> MobileNumber  ,
    string Message ,
    bool SendToBlocksNumber ,
    double? SendTimeSpan 
    );