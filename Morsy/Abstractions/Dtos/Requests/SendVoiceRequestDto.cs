namespace Morsy.Abstractions.Dtos.Requests;

public record SendVoiceRequestDto(
    long VoiceId,
    List<string> MobileNumber,
    short MaxTry,
    int MinuteBetweenTries,
    double SecondsBetweenTries,
    double EndTimeSpan,
    bool HasVote
);