using System;

namespace card_games_sim.Cards.Uno;

public abstract class UnoCard : Card
{
  public enum UnoCardColors
  {
    Red,
    Green,
    Blue,
    Yellow,
    Wild,
  }

  public UnoCardColors CardColor { get; init; }

  protected UnoCard(UnoCardColors color)
  {
    CardColor = color;
  }

  public abstract bool Matches(UnoCard other);
  public abstract void Play(); //Hay que checar primero si match -> luego, sisí, colocarla -> luego en SpecialUnoCard aplicar efecto
}
