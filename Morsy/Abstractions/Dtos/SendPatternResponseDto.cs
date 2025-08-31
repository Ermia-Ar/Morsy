namespace Morsy.Abstractions.Dtos;

public class SendPatternResponseDto
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }
    
    [JsonPropertyName("message")]
    public string Message { get; set; }
}