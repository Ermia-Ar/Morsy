namespace Morsy.Abstractions.Dtos;

public record GetStatusRequestDto(
    List<string> MessageIds
);
