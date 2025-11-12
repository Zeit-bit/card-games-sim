using card_games_sim.Games;
using card_games_sim.Players;

namespace card_games_sim;

class Program
{
  static void Main(string[] args)
  {
    GameSelector();
  }

  static void GameSelector()
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
              [
                new("Pancho"),
                new BlackjackCautiousPlayer("Jorge"),
                new BlackjackRecklessPlayer("Robocop"),
              ]
            )
        )
      },
      {
        "2",
        new(
          "Uno",
          () =>
            new UnoGame(
              [
                new("Mike"),
                new UnoCalculatingPlayer("Jaime"),
                new("Dario"),
                new UnoCalculatingPlayer("Rizzra"),
              ]
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
