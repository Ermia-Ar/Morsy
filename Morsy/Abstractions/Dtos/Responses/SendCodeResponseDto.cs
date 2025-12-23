namespace Morsy.Abstractions.Dtos.Responses;

public record SendCodeResponseDto(
    bool Success,
    string Message
    );