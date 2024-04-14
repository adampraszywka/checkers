using FluentResults;

namespace Domain.Lobby.Errors;

public class AlreadyClosed() : Error("Lobby is already closed")
{
    
}