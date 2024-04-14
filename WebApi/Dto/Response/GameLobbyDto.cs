using Domain.Lobby;
using Domain.Shared;

namespace WebApi.Dto.Response;

public record GameLobbyDto
{
    public string Id { get; }
    public string Name { get; } 
    public IEnumerable<ParticipantDto> Participants { get; }

    public GameLobbyDto(GameLobby gameLobby)
    {
        Id = gameLobby.Id;
        Name = gameLobby.Name;
        Participants = gameLobby.Participants.Select(x => new ParticipantDto(x));
    }
}

public record ParticipantDto
{
    public string Name { get; }
    public Color Color { get; }

    public ParticipantDto(Participant participant)
    {
        Name = participant.Player.Id;
        Color = participant.Color;
    }
}