using card_games_sim.Games;
using card_games_sim.Players;

namespace card_games_sim.Cards.Uno.SpecialCards
{
  public class SkipUnoCard : SpecialUnoCard
  {
    public SkipUnoCard(UnoCardColors color)
      : base(color, UnoCardSymbols.Skip) { }

    public override string Name
    {
      get { return $"Skip {CardColor}"; }
    }

    public override void ApplySpecialEffect(UnoGame game)
    {
      Console.WriteLine("Blocking the next player turn");
      int nextPlayerIndex = game.GetNextTurn(game.CurrentPlayerIndex);
      var nextPlayer = (UnoPlayer)game.Players[nextPlayerIndex];
      nextPlayer.Blocked = true;
    }
  }
}
