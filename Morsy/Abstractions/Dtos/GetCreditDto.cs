namespace Morsy.Abstractions.Dtos;

public class GetCreditDto
{
    public bool Success { get; set; }

    public string Message { get; set; } = null!;

    public List<Object> Result { get; set; } = null!;
}