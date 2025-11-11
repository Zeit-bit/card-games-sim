using System;

namespace card_games_sim.Cards.Uno;

public class NumericUnoCard : UnoCard
{
  private readonly int _value;
  public int Value
  {
    get { return _value; }
    init
    {
      if (value < 0 || value > 9)
        throw new Exception("Uno card numeric values must only be from 0 to 9");

      _value = value;
    }
  }

  public NumericUnoCard(int value, UnoCardColors color)
    : base(color)
  {
    Value = value;
  }

  public override string Name
  {
    get { return $"{this.Value} {this.CardColor}"; }
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
