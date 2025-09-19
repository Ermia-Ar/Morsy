namespace Morsy.Abstractions.Dtos;

public record GetStatusResponseDto(
    bool Success,
    string Message,
    List<object> Data
);