using card_games_sim.Cards.Uno;
using card_games_sim.Games;

namespace card_games_sim.Players;

public class UnoCalculatingPlayer : UnoPlayer
{
  public UnoCalculatingPlayer(string name)
    : base(name) { }

  protected override UnoCard? SelectCard(UnoCard[] matchingCards, UnoGame game)
  {
    if (matchingCards.Length == 0)
      return null;

    var nextPlayer = game.Players[game.GetNextTurn(game.CurrentPlayerIndex)];
    int nextPlayerCardCount = nextPlayer.Hand.Count();

    if (nextPlayerCardCount > 1)
    {
      var playCard = matchingCards.FirstOrDefault(card =>
        card.CardSymbol == UnoCard.UnoCardSymbols.Number
      );
      return playCard;
    }

    Hand.Sort((c1, c2) => ((UnoCard)c1).CardSymbol.CompareTo(((UnoCard)c2).CardSymbol));
    if (((UnoCard)Hand[0]).CardSymbol != UnoCard.UnoCardSymbols.Number)
      return (UnoCard)Hand[0];

    return null;
  }
}
