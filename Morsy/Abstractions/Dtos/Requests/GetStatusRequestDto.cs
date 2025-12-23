namespace Morsy.Abstractions.Dtos.Requests;

public record GetStatusRequestDto(
    List<string> MessageId
);
