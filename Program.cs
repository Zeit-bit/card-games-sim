namespace card_games_sim;

class Program
{
    static void Main(string[] args)
    {
        /*
        Stores keys to select different games
        the value contains the name of the game, and a function that
        returns an instance of the selected game
        */
        var games = new Dictionary<string, Tuple<string, Func<Game>>>()
        {
            {
                "1",
                new(
                    "Blackjack",
                    () =>
                        new BlackjackGame(
                            10,
                            new BlackjackPlayer[]
                            {
                                new(),
                                new BlackJackCautiousPlayer(),
                                new BlackjackRecklessPlayer(),
                            }
                        )
                )
            },
            {
                "2",
                new(
                    "Uno",
                    () =>
                        new UnoGame(
                            new UnoPlayer[]
                            {
                                new(),
                                new UnoCalculatingPlayer(),
                                new(),
                                new UnoCalculatingPlayer(),
                            }
                        )
                )
            },
        };

        bool shouldAskForGame = true;
        while (shouldAskForGame)
        {
            Console.WriteLine("Choose game to simulate:");
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Key} -> {game.Value.Item1}");
            }

            string? selection = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(selection))
                continue;
            if (!games.ContainsKey(selection))
                continue;

            shouldAskForGame = false;
            var selectedGame = games[selection].Item2();
            selectedGame.Start();
        }
    }
}
