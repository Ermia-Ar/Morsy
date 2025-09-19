namespace Morsy.Abstractions.Dtos;

public record SendSmsResponseDto(
    bool Success ,
    string Message , 
    long[] MessageId
    );