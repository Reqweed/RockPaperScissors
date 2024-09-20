namespace RockPaperScissors;

public class Game
{
    private readonly string[] _moves;
    private readonly GameRules _gameRules;
    private readonly HmacGenerator _hmacGen;
    private readonly int _computerMove;

    public Game(string[] moves)
    {
        _moves = moves;
        _gameRules = new GameRules(moves);
        _hmacGen = new HmacGenerator();

        var random = new Random();
        _computerMove = random.Next(moves.Length);
    }

    public void Start()
    {
        var hmac = _hmacGen.GenerateHmac(_moves[_computerMove]);
        Console.WriteLine($"HMAC: {hmac}");

        while (true)
        {
            DisplayMoves();

            var input = Console.ReadLine();
            switch (input)
            {
                case "?":
                    HelpDisplay.ShowHelp(_moves);
                    break;

                case "0":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    if (int.TryParse(input, out var playerMove) && playerMove >= 1 && playerMove <= _moves.Length)
                    {
                        playerMove--;
                        HandlePlayerMove(playerMove);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }

                    break;
            }
        }
    }

    private void DisplayMoves()
    {
        Console.WriteLine("Available moves:");
        for (var i = 0; i < _moves.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {_moves[i]}");
        }

        Console.WriteLine("0 - Exit");
        Console.WriteLine("? - Help");
        Console.Write("Enter your move: ");
    }

    private void HandlePlayerMove(int playerMove)
    {
        Console.WriteLine($"Your move: {_moves[playerMove]}");
        Console.WriteLine($"Computer move: {_moves[_computerMove]}");

        var result = _gameRules.GetGameOutcome(playerMove, _computerMove);
        Console.WriteLine(result);
        Console.WriteLine($"HMAC key: {_hmacGen.Key}");
    }
}