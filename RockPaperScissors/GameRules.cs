namespace RockPaperScissors;

public class GameRules(string[] moves)
{
    public string GetGameOutcome(int playerMove, int computerMove)
    {
        var res = GetResult(playerMove, computerMove);
        return res switch
        {
            0 => "Draw",
            1 => "You win!",
            -1 => "Computer wins!",
            _ => ""
        };
    }
    
    public string GetResultForTable(int playerMove, int computerMove)
    {
        var res = GetResult(playerMove, computerMove);
        return res switch
        {
            0 => "Draw",
            1 => "Win",
            -1 => "Lose",
            _ => ""
        };
    }

    private int GetResult(int playerMove, int computerMove)
    {
        var p = moves.Length >> 1;
        var n = moves.Length;
        return Math.Sign((playerMove - computerMove + p + n) % n - p);
    }
}