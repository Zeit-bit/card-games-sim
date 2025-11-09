using card_games_sim.Games;

namespace card_games_sim.Players;

public class BlackjackPlayer : Player
{
  public BlackjackPlayer(string name)
    : base(name) { }

  public int Victories { get; set; }
  public int Value { get; private set; }

  public override void Play(Game game)
  {
    throw new NotImplementedException();
  }
}
