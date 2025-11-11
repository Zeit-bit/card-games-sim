using card_games_sim.Cards;
using card_games_sim.Players;

namespace card_games_sim.Games;

public class UnoGame : Game
{
  private UnoPlayer[] _players;
  protected override Player[] Players
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
  private Deck DrawPile { get; set; }
  private Deck DiscardPile { get; set; }
  private int Direction { get; set; }
  private Player? Winner { get; set; }

  public UnoGame(UnoPlayer[] players)
  {
    Direction = 1;
    Players = players;
  }

  public override void Start()
  {
    for (int playerIndex = 0; Winner == null; playerIndex = GetNextTurn(playerIndex))
    {
      var currentPlayer = Players[playerIndex];

      currentPlayer.Play(this);

      if (currentPlayer.Hand.Count == 0)
        Winner = currentPlayer;
    }
  }

  private int GetNextTurn(int playerIndex)
  {
    if (Direction == -1 && playerIndex == 0)
      return Players.Count() - 1;

    if (Direction == 1 && playerIndex == Players.Length - 1)
      return 0;

    return playerIndex + Direction;
  }
}
