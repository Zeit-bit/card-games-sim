using System;
using card_games_sim.Cards.Poker;

namespace card_games_sim.Cards
{
  public static class PokerDeckBuilder
  {
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
  }
}
