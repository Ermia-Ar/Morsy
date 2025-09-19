namespace Morsy.Abstractions.Dtos;

public record SendFromFromResponseDto(
    bool Success ,
    string Message , 
    long[] MessageId
    );