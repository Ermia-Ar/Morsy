namespace Morsy.Abstractions.Dtos;

public class GetStatusResponseDto
{
    public bool Success { get; set; }

    public string Message { get; set; } = null!;

    public List<Object> Date { get; set; } = null!;
}