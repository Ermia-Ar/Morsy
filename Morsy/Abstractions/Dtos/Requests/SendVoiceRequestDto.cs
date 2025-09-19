namespace Morsy.Abstractions.Dtos;

public record SendVoiceRequestDto(
    long VoiceId,
    List<string> MobileNumber,
    short MaxTry,
    int MinuteBetweenTries,
    double SecondsBetweenTries,
    double EndTimeSpan,
    bool HasVote
);