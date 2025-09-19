namespace Morsy.Abstractions.Dtos;

public record CheckCodeResponseDto(
    bool Success,
    string Message
    );