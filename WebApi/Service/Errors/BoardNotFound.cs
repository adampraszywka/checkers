using FluentResults;

namespace WebApi.Service.Errors;

public class BoardNotFound(string boardId) : Error($"Board {boardId} not found")
{
    
}