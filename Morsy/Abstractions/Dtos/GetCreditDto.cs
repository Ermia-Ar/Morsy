namespace Morsy.Abstractions.Dtos;

public class GetCreditDto
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;

    [JsonPropertyName("result")]
    public List<Object> Result { get; set; } = null!;
}