namespace Morsy.Abstractions.Dtos;

public record GetReceivedMessageResponseDto(
    bool Success,
    string Message,
    object Result
    );