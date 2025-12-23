namespace Morsy.Abstractions.Dtos.Responses;

public record SendP2PResponseDto(
    bool Success,
    string Message,
    long[] MessageId
);