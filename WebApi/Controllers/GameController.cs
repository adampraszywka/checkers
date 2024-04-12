using Domain.Chessboard;
using Domain.Chessboard.Configurations.Classic;
using Domain.Game;
using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Players;

namespace WebApi.Controllers;

public class GameController(GameRepository gameRepository, BoardRepository boardRepository) : Controller
{
    [HttpGet("/game/{gameId}")]
    public async Task<IActionResult> Get([FromRoute] string gameId)
    {
        var game = await gameRepository.Get(gameId);
        if (game is null)
        {
            return NotFound();
        }

        return Ok(game);
    }

    [HttpPost("/game")]
    public async Task<IActionResult> Create()
    {
        var gameId = Guid.NewGuid().ToString();
        var boardId = Guid.NewGuid().ToString();

        var game = new GameInstance(gameId, boardId);
        var board = new Board(boardId, ClassicConfiguration.NewBoard());

        await boardRepository.Save(board);
        await gameRepository.Save(game);

        return Ok(game);
    }

    [HttpPost("/game/{gameId}/join")]
    public async Task<IActionResult> Join([FromRoute] string gameId, [FromHeader(Name = HeaderPlayer.HeaderName)] string playerId)
    {
        var player = new HeaderPlayer(playerId);
        var game = await gameRepository.Get(gameId);
        if (game is null)
        {
            return NotFound();
        }

        var joinResult = game.Join(player);
        if (joinResult.IsFailed)
        {
            return BadRequest(new ErrorDto(joinResult.Errors));
        }

        await gameRepository.Save(game);

        return Ok(game);
    }
}