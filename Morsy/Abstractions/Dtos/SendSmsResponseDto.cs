namespace Morsy.Abstractions.Dtos;

public class SendSmsResponseDto
{
    [JsonPropertyName("success")]
    public bool Success {get; set;}
    
    [JsonPropertyName("message")]
    public string Message {get; set;} = null!;
    
    [JsonPropertyName("messageIds")]
    public List<string> MessageIds {get; set;} = null!;
}