namespace WebApi.Players.Error;

public class InvalidAiPlayerType(string type) : FluentResults.Error($"{type} is not a valid AI player type.")
{
    
}