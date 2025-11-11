using card_games_sim.Games;

namespace card_games_sim.Players;

public class BlackjackCautiousPlayer : BlackjackPlayer
{
  private int PointOfCut { get; set; }

  public BlackjackCautiousPlayer(string name)
    : base(name)
  {
    PointOfCut = Random.Shared.Next(8, 18);
  }

  public override void Play(Game game)
  {
    Play(PointOfCut, game);
  }
}
