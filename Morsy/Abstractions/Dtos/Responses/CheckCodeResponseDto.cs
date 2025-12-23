namespace Morsy.Abstractions.Dtos.Responses;

public record CheckCodeResponseDto(
    bool Success,
    string Message
    );