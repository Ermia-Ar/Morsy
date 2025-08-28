namespace Morsy.Abstractions.Dtos;

public class SendPatternRequestDto
{
    public long OtpId { get; set; }
    public string MobileNumber { get; set; }
    public List<object> ReplaceToken { get; set; } = new();
}