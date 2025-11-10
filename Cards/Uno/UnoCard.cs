using System;

namespace card_games_sim.Cards.Uno;

abstract public class UnoCard : Card
{
  public enum UnoCardColors
  {
    Red,
    Green,
    Blue,
    Yellow,
    Wild
  }

  private UnoCardColors _cardColor;
  public UnoCardColors CardColor
  {
    get { return _cardColor; }
    private set
    {
      _cardColor = value;
    }
  }

 protected UnoCard(UnoCardColors color)
  {
    CardColor = color;
  }

  protected abstract string GenerateCardName();

  public override string Name
  {
    get { return GenerateCardName(); }
  }

  public abstract bool Matches(UnoCard other);
  public abstract void Play(); //Hay que checar primero si match -> luego, sisí, colocarla -> luego en SpecialUnoCard aplicar efecto
}