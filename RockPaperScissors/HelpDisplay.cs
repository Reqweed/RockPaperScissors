using ConsoleTables;
namespace RockPaperScissors;

public static class HelpDisplay
{
    public static void ShowHelp(string[] moves)
    {
        var gameRules = new GameRules(moves);
        var moveCount = moves.Length;

        var table = new ConsoleTable(new[] { "v PC\\User >" }.Concat(moves).ToArray());
        
        for (var i = 0; i < moveCount; i++)
        {
            var row = new List<string> { moves[i] };
            for (var j = 0; j < moveCount; j++)
            {
                var result = gameRules.GetResultForTable(j, i);
                row.Add(result);
            }
            table.AddRow(row.ToArray());
        }
        
        table.Write(Format.Alternative);
    }
}