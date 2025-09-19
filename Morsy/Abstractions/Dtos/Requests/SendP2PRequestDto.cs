namespace Morsy.Abstractions.Dtos;

public record SendP2PRequestDto(
    string SenderNumber ,
    List<string> MobileNumber,
    List<string> Message,
    bool SendToBlocksNumber,
    double? SendTimeSpan
    );