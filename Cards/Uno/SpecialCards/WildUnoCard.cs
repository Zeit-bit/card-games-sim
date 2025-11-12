using System;
using card_games_sim.Games;

namespace card_games_sim.Cards.Uno.SpecialCards
{
  public class WildUnoCard : SpecialUnoCard
  {
    public WildUnoCard()
      : base(UnoCardColors.Wild, UnoSpecialTypes.Reverse) { }

    public override string Name
    {
      get { return $"Wild"; }
    }

    public override bool Matches(UnoCard other)
    {
      return true;
    }

    public override void ApplySpecialEffect(Game game)
    {
      throw new System.NotImplementedException();
    }
  }
}
