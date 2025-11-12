using card_games_sim.Games;

namespace card_games_sim.Cards.Uno;

public class UnoNumericCard : UnoCard
{
  public override string Name
  {
    get { return $"{Value} {CardColor}"; }
  }

  public UnoNumericCard(UnoCardColors cardColor, int value)
    : base(cardColor)
  {
    CardSymbol = UnoCardSymbols.Number;
    Value = value;
  }

  public override void Play(UnoGame game)
  {
    DiscardCard(game);
  }
}
