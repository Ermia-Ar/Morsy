namespace Morsy.Abstractions.Dtos;

public class SendP2PResponseDto
{
    public bool Success {get; set;}
    
    public string Message {get; set;} = null!;
    
    public List<string> MessageIds {get; set;} = null!;
}