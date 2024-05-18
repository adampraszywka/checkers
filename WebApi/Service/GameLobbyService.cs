using AIPlayers.Players;
using AIPlayers.Repository;
using Contracts.Notification;
using Domain.Chessboard;
using Domain.Lobby;
using Domain.Lobby.Errors;
using Domain.Shared;
using FluentResults;
using MassTransit;
using WebApi.Extensions;
using WebApi.Service.Errors;

namespace WebApi.Service;

public class GameLobbyService(
    GameLobbyRepository lobbyRepository,
    BoardRepository boardRepository,
    AIPlayerRepository aiPlayerRepository,
    AlgorithmPlayerFactory algorithmPlayerFactory,
    IPublishEndpoint publishEndpoint)
{
    public async Task<Result<GameLobby>> Get(string lobbyId)
    {
        var lobby = await lobbyRepository.Get(lobbyId);
        if (lobby is null)
        {
            return Result.Fail(new LobbyNotFound(lobbyId));
        }

        return Result.Ok(lobby);
    }

    public async Task<Result<GameLobby>> Create(Player player, string name)
    {
        var id = Guid.NewGuid().ToString();
        var lobby = new GameLobby(id, name);

        var result = lobby.Join(player);

        if (result.IsFailed)
        {
            return Result.Fail(new LobbyCreationFailed(result.Errors));
        }

        await lobbyRepository.Save(lobby);
        await LobbyUpdateNotification(lobby);
        
        return Result.Ok(lobby);
    }

    public async Task<Result<GameLobby>> Join(string lobbyId, Player player)
    {
        var lobby = await lobbyRepository.Get(lobbyId);
        if (lobby is null)
        {
            return Result.Fail(new LobbyNotFound(lobbyId));
        }

        var result = lobby.Join(player);
        if (result.HasError<PlayerAlreadyJoined>())
        {
            return Result.Fail(new LobbyJoinFailedPlayerAlreadyInLobby());
        }
        
        if (result.IsFailed)
        {
            return Result.Fail(new LobbyJoinFailed(result.Errors));
        }

        await lobbyRepository.Save(lobby);
        await LobbyUpdateNotification(lobby);

        return Result.Ok(lobby);
    }
    
    public async Task<Result<GameLobby>> AddAiPlayer(string lobbyId, string algorithm, Dictionary<string, string> configuration)
    {
        var lobby = await lobbyRepository.Get(lobbyId);
        if (lobby is null)
        {
            return Result.Fail(new LobbyNotFound(lobbyId));
        }

        var guid = Guid.NewGuid().ToString();
        var player = algorithmPlayerFactory.Create(guid, algorithm, configuration);
        if (player is null)
        {
            return Result.Fail(new LobbyAddAiPlayerFailed("Cannot create AI player"));
        }

        var result = lobby.Join(player);
        if (result.IsFailed)
        {
            return Result.Fail(new LobbyAddAiPlayerFailed(result.Errors));
        }

        await aiPlayerRepository.Save(player);
        await lobbyRepository.Save(lobby);
        await LobbyUpdateNotification(lobby);

        return Result.Ok(lobby);
    }

    public async Task<Result<Board>> Close(string lobbyId, Player player)
    {
        var lobby = await lobbyRepository.Get(lobbyId);
        if (lobby is null)
        {
            return Result.Fail(new LobbyNotFound(lobbyId));
        }

        var closeResult = lobby.Close(player, new ClassicBoardFactory());
        if (closeResult.IsFailed)
        {
            return Result.Fail(new LobbyCloseFailed(closeResult.Errors));
        }

        var board = closeResult.Value;

        await boardRepository.Save(board); 
        await lobbyRepository.Save(lobby);
        await LobbyUpdateNotification(lobby);

        return Result.Ok(board);
    }

    private Task LobbyUpdateNotification(GameLobby lobby) => publishEndpoint.Publish(new LobbyUpdated(lobby.ToDto()));
}