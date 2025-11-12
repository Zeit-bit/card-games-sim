using card_games_sim.Games;

namespace card_games_sim.Cards.Uno.SpecialCards
{
  public class WildUnoCard : SpecialUnoCard
  {
    public WildUnoCard()
      : base(UnoCardColors.Wild, UnoCardSymbols.Wild) { }

    public override string Name
    {
      get { return $"Wild Card : last color used {CardColor}"; }
    }

    public override void ApplySpecialEffect(UnoGame game)
    {
      int rnd = Random.Shared.Next(0, 4);
      var color = (UnoCardColors)rnd;
      Console.WriteLine($"Choosing color: {color}");
      CardColor = color;
    }
  }
}
