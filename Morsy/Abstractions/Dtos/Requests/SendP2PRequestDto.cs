namespace Morsy.Abstractions.Dtos.Requests;

public record SendP2PRequestDto(
    string SenderNumber ,
    List<string> MobileNumber,
    List<string> Message,
    bool SendToBlocksNumber,
    double? SendTimeSpan
    );