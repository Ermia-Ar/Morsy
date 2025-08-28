namespace Morsy.Abstractions.Dtos;



public class SendSmsRequestDto
{
    public string SenderNumber { get; set; } = null!;
    public List<string> MobileNumber { get; set; } = null!;
    public string Message { get; set; } = null!;
    public bool SendToBlocksNumber { get; set; }
    public 	double? SendTimeSpan { get; set; }
}