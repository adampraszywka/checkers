using FluentResults;

namespace Domain.Chessboard.Errors;

public class UnderperformingCaptureError(Position sourceSelected, IEnumerable<Position> sourceAvailable) : Error(BuildMessage(sourceSelected, sourceAvailable))
{
    public IEnumerable<Position> SourceAvailable => sourceAvailable;
    
    private static string BuildMessage(Position sourceSelected, IEnumerable<Position> sourceAvailable) =>
        $"The piece at {sourceSelected.Name} is unable to move. Pieces at {string.Join(", ", sourceAvailable.Select(x => x.Name))} have the capability to capture multiple opponent pieces, potentially more than the piece at {sourceSelected.Name}.";
}