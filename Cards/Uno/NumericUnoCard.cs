using System;

namespace card_games_sim.Cards.Uno;

public class NumericUnoCard : UnoCard
{
  private readonly int _value;
  public int Value
  {
    get { return _value; }
    init { _value = value; }
  }

  public NumericUnoCard(int value, UnoCardColors color)
  : base(color)
  {
    Value = value;
  }

  protected override string GenerateCardName()
  {
    return $"{this.Value} {this.CardColor}";
  }
  
  public override bool Matches(UnoCard other) //true if same color or same value
  {
    if (this.CardColor == other.CardColor)
      return true;

    if (other is NumericUnoCard num && num.Value == this.Value)
      return true;

    return false;
  }

  public override void Play()
  {
    throw new NotImplementedException();
  }
}
