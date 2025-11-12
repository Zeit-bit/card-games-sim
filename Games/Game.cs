using card_games_sim.Players;

namespace card_games_sim.Games;

public abstract class Game
{
  public abstract Player[] Players { get; init; }
  public abstract void Start();
}
