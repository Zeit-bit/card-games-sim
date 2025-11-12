using card_games_sim.Games;

namespace card_games_sim.Cards.Uno.SpecialCards
{
  public class ReverseUnoCard : SpecialUnoCard
  {
    public ReverseUnoCard(UnoCardColors color)
      : base(color, UnoCardSymbols.Reverse) { }

    public override string Name
    {
      get { return $"Reverse {CardColor}"; }
    }

    public override void ApplySpecialEffect(UnoGame game)
    {
      Console.WriteLine("Applying change to direction");
      game.Direction *= -1;
    }
  }
}
