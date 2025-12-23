namespace Morsy.Abstractions.Dtos.Responses;

public record GetCreditResponseDto(
    bool Success,
    string Message,
    object Result
);
     