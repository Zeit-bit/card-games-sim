using card_games_sim.Cards.Poker;

namespace card_games_sim.Interfaces;

public interface ICardValueRule
{
  int GetCardValue(PokerCard card);
}
