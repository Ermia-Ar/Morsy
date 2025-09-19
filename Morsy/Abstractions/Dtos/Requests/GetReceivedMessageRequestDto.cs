namespace Morsy.Abstractions.Dtos;

public record GetReceivedMessageRequestDto(
    string Number,
    int Page,
    int Size
);