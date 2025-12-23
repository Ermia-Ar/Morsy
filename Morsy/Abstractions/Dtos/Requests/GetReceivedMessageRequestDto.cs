namespace Morsy.Abstractions.Dtos.Requests;

public record GetReceivedMessageRequestDto(
    string Number,
    int Page,
    int Size
);