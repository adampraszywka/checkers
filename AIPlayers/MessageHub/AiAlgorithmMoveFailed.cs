using FluentResults;

namespace AIPlayers.MessageHub;

public class AiAlgorithmMoveFailed(IEnumerable<string> reasons) : Error(string.Join("", reasons));