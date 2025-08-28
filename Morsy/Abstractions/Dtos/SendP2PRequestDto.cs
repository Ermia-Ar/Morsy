namespace Morsy.Abstractions.Dtos;

public class SendP2PRequestDto
{
    public string SenderNumber { get; set; } = null!;
    public List<string> MobileNumber;
    public List<string> Message;
    public bool SendToBlocksNumber;
    public TimeSpan? SendAfter;
}