using Domain.Lobby;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Request;
using WebApi.Dto.Response;
using WebApi.Players;
using WebApi.Repository;

namespace WebApi.Controllers;

public class LobbyController(GameLobbyRepository lobbyRepository, GameLobbyListRepository lobbyListRepository) : ControllerBase
{
    [HttpGet("/lobby")]
    public async Task<IActionResult> GetAll()
    {
        var lobbies = await lobbyListRepository.GetAll();
        var dtos = lobbies.Select(x => new GameLobbyDto(x));
        return Ok(dtos);
    }

    [HttpGet("/lobby/{lobbyId}")]
    public async Task<IActionResult> Get([FromRoute] string lobbyId)
    {
        var lobby = await lobbyRepository.Get(lobbyId);
        if (lobby is null)
        {
            return NotFound();
        }

        var dto = new GameLobbyDto(lobby);
        return Ok(dto);
    }

    [HttpPost("/lobby")]
    public async Task<IActionResult> Create([FromBody] CreateLobbyRequest request, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var id = Guid.NewGuid().ToString();
        var lobby = new GameLobby(id, request.Name );

        var player = new HeaderPlayer(playerId);
        var result = lobby.Join(player);

        if (!result.IsSuccess)
        {
            return BadRequest(new ErrorDto(result.Errors));
        }

        await lobbyRepository.Save(lobby);

        var dto = new GameLobbyDto(lobby);
        return Ok(dto);
    }
    
    [HttpPost("/lobby/{lobbyId}/join")]
    public async Task<IActionResult> Join(string lobbyId, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var lobby = await lobbyRepository.Get(lobbyId);
        if (lobby is null)
        {
            return NotFound();
        }

        var player = new HeaderPlayer(playerId);
        var result = lobby.Join(player);

        if (result.IsSuccess)
        {
            var dto = new GameLobbyDto(lobby);
            return Ok(dto);
        }

        return BadRequest(new ErrorDto(result.Errors));
    }
}