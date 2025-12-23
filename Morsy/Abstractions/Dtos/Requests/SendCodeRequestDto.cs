namespace Morsy.Abstractions.Dtos.Requests;

public record SendCodeRequestDto(
    string Mobile,
    string Footer
);