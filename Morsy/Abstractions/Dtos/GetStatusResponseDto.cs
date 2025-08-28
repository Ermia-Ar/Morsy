using System.Text.Json.Serialization;

namespace Morsy.Abstractions.Dtos;

public class GetStatusResponseDto
{
    [JsonPropertyName("success")]
    public bool Success {get; set;}
    
    [JsonPropertyName("message")]
    public string Message {get; set;} = null!;

    [JsonPropertyName("date")]
    public List<Object> Date { get; set; } = null!;
}