using card_games_sim.Cards;
using card_games_sim.Players;
using card_games_sim.Utils;

namespace card_games_sim.Games;

public class UnoGame : Game
{
  private UnoPlayer[] _players;
  public override Player[] Players
  {
    get { return _players; }
    init
    {
      if (value.Length <= 0)
        throw new Exception("A minimum of 1 player is necessary");
      if (value.Length > 16)
        throw new Exception("There can only be up to 16 players");

      _players = (UnoPlayer[])value;
    }
  }
  public Deck DrawPile { get; set; }
  public Deck DiscardPile { get; set; }
  public int Direction { get; set; }
  private Player? Winner { get; set; }
  public int CurrentPlayerIndex { get; set; }
  public int AccumulatedDrawCount { get; set; }

  public UnoGame(UnoPlayer[] players)
  {
    Direction = 1;
    Players = players;
    DrawPile = DeckManager.CreateStandardUnoDeck();
    DeckManager.ShuffleCards(DrawPile);
    DiscardPile = new Deck();
  }

  public override void Start()
  {
    ((UnoPlayer)Players[0]).DealCards(4, DrawPile, Players);

    DiscardPile.Cards.Push(DrawPile.Cards.Pop());

    for (int playerIndex = 0; Winner == null; playerIndex = GetNextTurn(playerIndex))
    {
      CurrentPlayerIndex = playerIndex;
      var currentPlayer = Players[CurrentPlayerIndex];

      currentPlayer.Play(this);

      if (currentPlayer.Hand.Count == 1)
        Console.WriteLine($"{Players[CurrentPlayerIndex].Name} shouts UNO!");
      if (currentPlayer.Hand.Count == 0)
        Winner = currentPlayer;
    }

    Console.WriteLine($"Winner: {Winner.Name}");
  }

  public int GetNextTurn(int playerIndex)
  {
    if (Direction == -1 && playerIndex == 0)
      return Players.Count() - 1;

    if (Direction == 1 && playerIndex == Players.Length - 1)
      return 0;

    return playerIndex + Direction;
  }
}
