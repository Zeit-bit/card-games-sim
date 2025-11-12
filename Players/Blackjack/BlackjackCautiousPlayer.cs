using card_games_sim.Games;

namespace card_games_sim.Players;

public class BlackjackCautiousPlayer : BlackjackPlayer
{
  private int PointOfCut { get; set; }

  public BlackjackCautiousPlayer(string name)
    : this(name, Random.Shared.Next(8, 18)) { }

  public BlackjackCautiousPlayer(string name, int pointOfCut)
    : base(name)
  {
    PointOfCut = pointOfCut;
  }

  public override void Play(Game game)
  {
    Play(PointOfCut, game);
  }
}
