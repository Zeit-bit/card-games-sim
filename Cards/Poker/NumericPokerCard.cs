using System;

namespace card_games_sim.Cards.Poker;

public class NumericPokerCard : PokerStandardCard
{
  public int Value { get; private init; }

  public NumericPokerCard(int value, PokerCardSuits suit)
    : base(suit)
  {
    if (value < 2 || value > 10)
      throw new Exception("Poker numeric cards must be between 2 and 10.");

    Value = value;
  }

  public override string Name
  {
    get { return $"{Value} of {CardSuit}"; }
  }

  public override void Play()
  {
    throw new System.NotImplementedException();
  }
}
