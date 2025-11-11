using System;

namespace card_games_sim.Cards.Poker;

public abstract class PokerStandardCard : PokerCard
{
  public enum PokerCardSuits
  {
    Hearts,
    Diamonds,
    Spades,
    Clubs,
  }

  public enum PokerCardColors
  {
    Red,
    Black,
  }

  public PokerCardSuits CardSuit { get; init; }

  public PokerCardColors CardColor
  {
    get
    {
      return (CardSuit == PokerCardSuits.Hearts || CardSuit == PokerCardSuits.Diamonds)
        ? PokerCardColors.Red
        : PokerCardColors.Black;
    }
  }

  protected PokerStandardCard(PokerCardSuits suit)
  {
    CardSuit = suit;
  }
}
