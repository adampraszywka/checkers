﻿using Domain.Chessboard.Configurations;
using Domain.Chessboard.Errors;
using Domain.Chessboard.GameStates;
using Domain.Chessboard.PieceMoves;
using Domain.Chessboard.Pieces;
using Extension;
using FluentResults;

namespace Domain.Chessboard;

public class Board
{
    private readonly BoardSize _boardSize;
    private readonly GameState _gameState;
    private readonly PieceFactory _pieceFactory;
    private readonly PieceMoveFactory _pieceMoveFactory;
    private readonly Square[,] _squares;

    public Board(string id, Configuration configuration)
    {
        Id = id;
        _boardSize = configuration.BoardSize;
        _pieceMoveFactory = configuration.MoveFactory;
        _pieceFactory = configuration.PieceFactory;
        _gameState = configuration.GameState;
        _squares = new Square[_boardSize.Rows, _boardSize.Columns];

        for (var row = 0; row < _boardSize.Rows; row++)
        {
            for (var column = 0; column < _boardSize.Columns; column++)
            {
                _squares[row, column] = Square.FromCoordinates(new Position(row, column));
            }
        }
        
        foreach (var (piece, position) in configuration.PiecesPositions)
        {
            if (!position.IsWithinBoard(_boardSize))
            {
                //TODO: Catch an error and throw it in exception?
                throw new NotImplementedException();
            }
            
            var square = _squares[position.Row, position.Column];
            square.Move(piece);
        }
    }

    public string Id { get; }
    public BoardSnapshot Snapshot => GenerateSnapshot();
    public GameStateSnapshot GameState => _gameState.Snapshot;

    public Result<IEnumerable<PossibleMove>> PossibleMoves(Position source)
    {
        if (!source.IsWithinBoard(_boardSize))
        {
            return Result.Fail(new PositionOutOfBoard(source));
        }

        var square = _squares[source.Row, source.Column];
        if (!square.IsOccupied) return Result.Fail(new EmptySquare(source));

        var piece = square.Piece;
        var pieceMove = _pieceMoveFactory.For(piece);
        var possibleMoves = pieceMove.PossibleMoves(square.Position, Snapshot);
        return Result.Ok(possibleMoves);
    }

    public Result Move(Position source, Position target)
    {
        if (!source.IsWithinBoard(_boardSize))
        {
            return Result.Fail(new PositionOutOfBoard(source));
        }

        if (!target.IsWithinBoard(_boardSize))
        {
            return Result.Fail(new PositionOutOfBoard(target));
        }

        var square = _squares[source.Row, source.Column];
        if (!square.IsOccupied)
        {
            return Result.Fail(new EmptySquare(source));
        }

        var piece = square.Piece;

        if (!_gameState.IsMoveAllowed(piece))
        {
            return Result.Fail(new InvalidMoveOrder(_gameState.Snapshot.CurrentPlayer));
        }

        var pieceMove = _pieceMoveFactory.For(piece);

        var possibleMoves = pieceMove.PossibleMoves(square.Position, Snapshot);
        var move = possibleMoves.FirstOrDefault(x => x.To == target);

        if (move is null) return Result.Fail(new MoveNotAllowed());

        foreach (var affectedSquarePosition in move.AffectedSquares)
        {
            var affectedSquare = _squares[affectedSquarePosition.Row, affectedSquarePosition.Column];
            if (affectedSquare.IsOccupied) affectedSquare.RemovePiece();
        }

        var newSquare = _squares[target.Row, target.Column];

        if (pieceMove.UpgradeRequired(target))
        {
            var upgradedPiece = _pieceFactory.ReplacementFor(piece);
            square.RemovePiece();
            newSquare.Move(upgradedPiece);
        }
        else
        {
            square.RemovePiece();
            newSquare.Move(piece);
        }

        _gameState.RegisterMove(piece, source, target);

        return Result.Ok();
    }

    private BoardSnapshot GenerateSnapshot()
    {
        return new BoardSnapshot(_boardSize, _gameState.Snapshot, _squares.Transform(s => s.Snapshot()));
    }
}