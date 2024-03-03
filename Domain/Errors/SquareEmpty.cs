using FluentResults;

namespace Domain.Errors;

public class SquareEmpty() : Error("Cannot remove piece from empty square");