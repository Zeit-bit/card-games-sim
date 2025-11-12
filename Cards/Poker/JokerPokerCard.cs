namespace card_games_sim.Cards.Poker;

public class JokerPokerCard : PokerCard
{
  public override string Name
  {
    get { return "Joker"; }
  }

  public override void Play()
  {
    throw new System.NotImplementedException();
  }
}
