namespace Morsy.Abstractions.Dtos.Responses;

public record SendFromFromResponseDto(
    bool Success ,
    string Message , 
    long[] MessageId
    );