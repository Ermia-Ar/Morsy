namespace Morsy.Abstractions.Dtos;

public record GetCreditResponseDto(
    bool Success,
    string Message,
    object Result
);
     