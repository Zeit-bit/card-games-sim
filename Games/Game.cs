using card_games_sim.Players;

namespace card_games_sim.Games;

public abstract class Game
{
  protected abstract Player[] Players { get; init; }
  public abstract void Start();
}
