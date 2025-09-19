namespace Morsy.Abstractions.Dtos;

public record SendFromFromRequestDto(
    string SenderNumber	, 
    List<string> MobileNumber,
    string Message,
    string ApiKey
    );