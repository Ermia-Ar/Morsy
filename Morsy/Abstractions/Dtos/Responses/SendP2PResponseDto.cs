namespace Morsy.Abstractions.Dtos;

public record SendP2PResponseDto(
    bool Success,
    string Message,
    long[] MessageId
);