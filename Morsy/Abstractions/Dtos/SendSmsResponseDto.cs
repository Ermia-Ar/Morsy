namespace Morsy.Abstractions.Dtos;

public class SendSmsResponseDto
{
    public bool Success {get; set;}
    
    public string Message {get; set;} = null!;
    
    public List<string> MessageIds {get; set;} = null!;
}