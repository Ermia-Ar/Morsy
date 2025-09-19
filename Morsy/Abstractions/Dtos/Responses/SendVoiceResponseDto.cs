namespace Morsy.Abstractions.Dtos;

public record  SendVoiceResponseDto(
    bool Success,
    string Message,
    string[] MessageId
);