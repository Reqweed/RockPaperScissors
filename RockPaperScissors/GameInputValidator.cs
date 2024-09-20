namespace RockPaperScissors;

public static class GameInputValidator
{
    public static void Validate(string[] moves)
    {
        if (moves.Length < 3 || moves.Length % 2 == 0)
        {
            throw new ArgumentException("Odd number of moves expected (>1).");
        }
        if (moves.Distinct().Count() != moves.Length)
        {
            throw new ArgumentException("Moves must be unique.");
        }
    }
}