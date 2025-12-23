namespace Morsy.Abstractions.Dtos.Responses;

public record GetStatusResponseDto(
    bool Success,
    string Message,
    List<object> Data
);