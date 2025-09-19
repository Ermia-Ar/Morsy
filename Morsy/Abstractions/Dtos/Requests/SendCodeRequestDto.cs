namespace Morsy.Abstractions.Dtos;

public record SendCodeRequestDto(
    string Mobile,
    string Footer
);