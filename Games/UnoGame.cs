using card_games_sim.Players;

namespace card_games_sim.Games;

public class UnoGame : Game
{
  protected override Player[] Players
  {
    get => throw new NotImplementedException();
    init => throw new NotImplementedException();
  }

  public UnoGame(UnoPlayer[] players)
  {
    Players = players;
  }

  public override void Start()
  {
    throw new NotImplementedException();
  }
}
