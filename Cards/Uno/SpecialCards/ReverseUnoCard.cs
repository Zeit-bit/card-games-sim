using System;
using card_games_sim.Games;

namespace card_games_sim.Cards.Uno.SpecialCards
{
  public class ReverseUnoCard : SpecialUnoCard
  {
    public ReverseUnoCard(UnoCardColors color)
      : base(color, UnoSpecialTypes.Reverse) { }

    public override string Name
    {
      get { return $"Reverse {CardColor}"; }
    }

    public override void ApplySpecialEffect(Game game)
    {
      throw new System.NotImplementedException();
    }
  }
}
