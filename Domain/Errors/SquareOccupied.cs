using FluentResults;

namespace Domain.Errors;

public class SquareOccupied() : Error("There is a different piece on selected square");