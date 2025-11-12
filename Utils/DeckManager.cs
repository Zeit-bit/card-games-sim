using card_games_sim.Cards;
using card_games_sim.Cards.Poker;
using card_games_sim.Cards.Uno;
using card_games_sim.Cards.Uno.SpecialCards;
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

  public static Deck CreateStandardPokerDeck()
  {
    var deck = new Deck();
    var suits = Enum.GetValues(typeof(PokerStandardCard.PokerCardSuits));
    var faceRanks = Enum.GetValues(typeof(PokerFaceCard.FaceRank));

    foreach (PokerStandardCard.PokerCardSuits suit in suits)
    {
      for (int value = 2; value <= 10; value++)
        deck.Cards.Push(new NumericPokerCard(value, suit));

      foreach (PokerFaceCard.FaceRank rank in faceRanks)
        deck.Cards.Push(new PokerFaceCard(rank, suit));
    }

    return deck;
  }

  public static Deck CreateStandardUnoDeck()
  {
    var deck = new Deck();

    // 2 times
    for (int count = 1; count <= 2; count++)
    {
      // foreach color
      for (int color = 0; color <= 3; color++)
      {
        // From 0 to 9
        for (int value = 0; value <= 9; value++)
        {
          // Adds only one per color for value 0
          if (count == 2 && value == 0)
            continue;
          deck.Cards.Push(new UnoNumericCard((UnoCard.UnoCardColors)color, value));
        }
        // Skip + Reverse + Draw2
        deck.Cards.Push(new SkipUnoCard((UnoCard.UnoCardColors)color));
        deck.Cards.Push(new ReverseUnoCard((UnoCard.UnoCardColors)color));
        deck.Cards.Push(new DrawCard((UnoCard.UnoCardColors)color, 2));
      }
      // Draw4 + Wild
      deck.Cards.Push(new DrawCard(UnoCard.UnoCardColors.Wild, 4));
      deck.Cards.Push(new WildUnoCard());
    }
    // 2 times more for Draw4 + Wild
    for (int count = 1; count <= 2; count++)
    {
      deck.Cards.Push(new DrawCard(UnoCard.UnoCardColors.Wild, 4));
      deck.Cards.Push(new WildUnoCard());
    }

    return deck;
  }
}
