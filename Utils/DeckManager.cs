using card_games_sim.Cards;
using card_games_sim.Players;

namespace card_games_sim.Utils;

public static class DeckManager
{
  public static void DealCards(int qtyToDeal, Deck deck, Player[] players)
  {
    var deckPile = deck.Cards;
    foreach (var player in players)
    {
      for (int i = 0; i < qtyToDeal; i++)
      {
        var cardToDeal = deckPile.Pop();
        player.AddCardToHand(cardToDeal);
      }
    }
  }

  public static void ShuffleCards(Deck deck)
  {
    var shuffledPile = deck.Cards.ToArray();
    for (int i = 0; i < shuffledPile.Length; i++)
    {
      int randomPos = Random.Shared.Next(0, shuffledPile.Length);
      (shuffledPile[i], shuffledPile[randomPos]) = (shuffledPile[randomPos], shuffledPile[i]);
    }
    deck.Cards = new Stack<Card>(shuffledPile);
  }
}
