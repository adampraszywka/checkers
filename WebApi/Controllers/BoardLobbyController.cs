using Domain.Chessboard;
using Domain.Lobby;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto.Response;
using WebApi.Extensions;
using WebApi.Players;

namespace WebApi.Controllers;

public class BoardLobbyController(GameLobbyRepository lobbyRepository, BoardRepository boardRepository) : ControllerBase
{
    [HttpPost("/lobby/{lobbyId}/close")]
    public async Task<IActionResult> Close([FromRoute] string lobbyId, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var lobby = await lobbyRepository.Get(lobbyId);
        if (lobby is null)
        {
            return NotFound();
        }

        var player = new HeaderPlayer(playerId);
        var boardFactory = new ClassicBoardFactory();
        var closeResult = lobby.Close(player, boardFactory);
        if (closeResult.IsFailed)
        {
            return BadRequest(new ErrorDto(closeResult.Errors));
        }

        var board = closeResult.Value;

        await boardRepository.Save(board);
        await lobbyRepository.Save(lobby);

        return Ok(board.ToDto());
    }
}