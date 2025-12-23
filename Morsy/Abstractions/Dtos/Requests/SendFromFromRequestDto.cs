namespace Morsy.Abstractions.Dtos.Requests;

public record SendFromFromRequestDto(
    string SenderNumber	, 
    List<string> MobileNumber,
    string Message,
    string ApiKey
    );