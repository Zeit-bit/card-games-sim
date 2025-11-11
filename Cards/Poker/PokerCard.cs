using System;

namespace card_games_sim.Cards.Poker;

abstract public class PokerCard : Card
{
  protected abstract string GenerateCardName();

  public override string Name
  {
    get { return GenerateCardName(); }
  }
  
  public abstract void Play(); 
}
