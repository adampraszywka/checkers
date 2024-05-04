using AIPlayers.Extensions;
using Contracts.Dto;

namespace AIPlayers.Players.Shared;

public static class BoardDtoExtensions
{
    public static string ToBoardState(this BoardDto dto)
    {
        var tmp = "```state of the board\n";

        foreach (var square in dto.Squares.SelectMany(x => x))
        {
            if (square.Piece is not null)
            {
                var name = square.Position.ToName();
                var color = square.Piece?.Color.ToString() ?? "";
                var piece = square.Piece?.Type.ToString() ?? "Empty";
            
                var result = $"{name}: {color} {piece}";
            
                tmp += result + "\n";
            }
        }

        return tmp;
    }
}