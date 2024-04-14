using Domain.Lobby;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Request;
using WebApi.Dto.Response;
using WebApi.Extensions;
using WebApi.Players;
using WebApi.Repository;
using WebApi.Service;

namespace WebApi.Controllers;

public class LobbyController(GameLobbyListRepository lobbyListRepository, GameLobbyService lobbyService) : ControllerBase
{
    [HttpGet("/lobby")]
    public async Task<IActionResult> GetAll()
    {
        var lobbies = await lobbyListRepository.GetAll();
        return Ok(lobbies.ToDto());
    }

    [HttpGet("/lobby/{lobbyId}")]
    public async Task<IActionResult> Get([FromRoute] string lobbyId)
    {
        var lobbyResult = await lobbyService.Get(lobbyId);
        if (lobbyResult.IsFailed)
        {
            return BadRequest(new ErrorDto(lobbyResult.Errors));
        }

        return Ok(lobbyResult.Value.ToDto());
    }

    [HttpPost("/lobby")]
    public async Task<IActionResult> Create([FromBody] CreateLobbyRequest request, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var player = new HeaderPlayer(playerId);
        var createResult = await lobbyService.Create(player, request.Name);

        if (!createResult.IsSuccess)
        {
            return BadRequest(new ErrorDto(createResult.Errors));
        }
        return Ok(createResult.Value.ToDto());
    }
    
    [HttpPost("/lobby/{lobbyId}/join")]
    public async Task<IActionResult> Join(string lobbyId, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var player = new HeaderPlayer(playerId);
        var joinResult = await lobbyService.Join(lobbyId, player);

        if (joinResult.IsFailed)
        {
            return BadRequest(new ErrorDto(joinResult.Errors));
        }

        return Ok(joinResult.Value.ToDto());
    }
}