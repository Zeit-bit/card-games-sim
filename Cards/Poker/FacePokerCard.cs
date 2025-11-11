using System;

namespace card_games_sim.Cards.Poker;

public class PokerFaceCard : PokerStandardCard
{
  public enum FaceRank
  {
    Jack,
    Queen,
    King,
    Ace,
  }

  public FaceRank Rank { get; private init; }

  public PokerFaceCard(FaceRank rank, PokerCardSuits suit)
    : base(suit)
  {
    Rank = rank;
  }

  public override string Name
  {
    get { return $"{Rank} of {CardSuit}"; }
  }

  public override void Play()
  {
    throw new System.NotImplementedException();
  }
}
