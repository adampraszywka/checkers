using FluentResults;

namespace Domain.Game.Errors;

public class GameQuotaReached() : Error("Game quota reached. Only two players are allowed to join the game");