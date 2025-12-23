namespace Morsy.Abstractions.Dtos.Responses;

public record SendSmsResponseDto(
    bool Success ,
    string Message , 
    long[] MessageId
    );