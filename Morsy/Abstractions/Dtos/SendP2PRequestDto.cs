namespace Morsy.Abstractions.Dtos;

public class SendP2PRequestDto(
    string SenderNumber ,
    List<string> MobileNumber,
    List<string> Message,
    bool SendToBlocksNumber,
    double? SendAfter
    );