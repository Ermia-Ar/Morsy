namespace Morsy.Abstractions.Dtos.Responses;

public record CancelUserOneMessageResponseDto(
    bool Success,
    string Message
    );