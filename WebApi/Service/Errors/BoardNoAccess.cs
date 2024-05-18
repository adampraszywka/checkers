using Domain.Chessboard;
using Domain.Shared;
using FluentResults;

namespace WebApi.Service.Errors;

public class BoardNoAccess(Player player, string boardId) : Error($"{player.Id} does not have access to {boardId}")
{
    
}