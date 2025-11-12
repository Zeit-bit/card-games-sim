using System;
using card_games_sim.Games;

namespace card_games_sim.Cards.Uno.SpecialCards;

public abstract class SpecialUnoCard : UnoCard
{
  public enum UnoSpecialTypes
  {
    Reverse,
    Skip,
    DrawTwo,
    DrawFour,
    Wild,
  }

  public UnoSpecialTypes SpecialType { get; init; }

  protected SpecialUnoCard(UnoCardColors color, UnoSpecialTypes specialType)
    : base(color)
  {
    SpecialType = specialType;
  }

  public override bool Matches(UnoCard other) //true if same color or same type
  {
    if (this.CardColor == other.CardColor)
      return true;

    if (other is SpecialUnoCard special && special.SpecialType == this.SpecialType)
      return true;

    return false;
  }

  public override void Play() //Check if matches -> Place -> ApplySpecialEffect
  {
    throw new System.NotImplementedException();
  }

  public abstract void ApplySpecialEffect(Game game);
}
