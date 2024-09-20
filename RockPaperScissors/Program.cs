using RockPaperScissors;

try
{
    GameInputValidator.Validate(args);

    var game = new Game(args);
    game.Start();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine("Example: Rock Paper Scissors");
}