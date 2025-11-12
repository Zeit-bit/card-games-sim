using System;
using card_games_sim.Games;

namespace card_games_sim.Cards.Uno.SpecialCards
{
  public class SkipUnoCard : SpecialUnoCard
  {
    public SkipUnoCard(UnoCardColors color)
      : base(color, UnoSpecialTypes.Reverse) { }

    public override string Name
    {
      get { return $"Skip {CardColor}"; }
    }

    public override void ApplySpecialEffect(Game game)
    {
      throw new System.NotImplementedException();
    }
  }
}
