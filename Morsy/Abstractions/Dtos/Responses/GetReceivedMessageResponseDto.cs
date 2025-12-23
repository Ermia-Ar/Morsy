namespace Morsy.Abstractions.Dtos.Responses;

public record GetReceivedMessageResponseDto(
    bool Success,
    string Message,
    object Result
    );