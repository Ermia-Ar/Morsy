namespace Morsy.Abstractions.Dtos.Requests;

public record CheckCodeRequestDto(
    string Mobile,
    string Code
);