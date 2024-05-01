namespace AIPlayers.Players.OpenAIGpt4Turbo;

public static class Rules
{
    public const string Game = @"
        Game rules:    
        - Pieces are placed on dark squares
        - Capture is mandatory, if possible
        - Piece can be moved diagonally by one square, in case they don't capture
        - White pieces move upwards (A1 to A8)
        - Black pieces move downwards (A8 to A1)";
    
    public const string BoardFormat = @"
        ```expected state of the board format:
        Field: Piece

        If field is not on the list, it means it's empty";
}