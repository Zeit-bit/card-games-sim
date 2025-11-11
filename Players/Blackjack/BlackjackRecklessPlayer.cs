using card_games_sim.Games;

namespace card_games_sim.Players;

public class BlackjackRecklessPlayer : BlackjackPlayer
{
  public BlackjackRecklessPlayer(string name)
    : base(name) { }

  public override void Play(Game game)
  {
    Play(21, game);
  }
}
