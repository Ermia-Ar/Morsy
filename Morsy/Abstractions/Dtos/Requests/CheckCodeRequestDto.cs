namespace Morsy.Abstractions.Dtos;

public record CheckCodeRequestDto(
    string Mobile,
    string Code
);