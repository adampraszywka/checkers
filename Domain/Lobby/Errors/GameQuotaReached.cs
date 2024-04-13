using FluentResults;

namespace Domain.Lobby.Errors;

public class GameQuotaReached() : Error("Game quota reached. Only two players are allowed to join the game");