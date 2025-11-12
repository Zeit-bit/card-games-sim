using card_games_sim.Games;

namespace card_games_sim.Cards.Uno.SpecialCards;

public abstract class SpecialUnoCard : UnoCard
{
  protected SpecialUnoCard(UnoCardColors color, UnoCardSymbols specialSymbol)
    : base(color)
  {
    if (specialSymbol == UnoCardSymbols.Number)
      throw new Exception("A numeric card can't be special");
    CardSymbol = specialSymbol;
  }

  public abstract void ApplySpecialEffect(UnoGame game);

  public sealed override void Play(UnoGame game)
  {
    DiscardCard(game);
    ApplySpecialEffect(game);
  }
}
