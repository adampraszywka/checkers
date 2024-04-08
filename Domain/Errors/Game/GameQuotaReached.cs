using FluentResults;

namespace Domain.Errors.Game;

public class GameQuotaReached(): Error("Game quota reached. Only two players are allowed to join the game");