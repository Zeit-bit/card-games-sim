using System;

namespace card_games_sim.Cards.Poker;

public class JokerPokerCard : PokerCard
{
  protected override global::System.String GenerateCardName()
  {
    return "Joker";
  }

  public override void Play()
  {
    throw new System.NotImplementedException();
  }
}
