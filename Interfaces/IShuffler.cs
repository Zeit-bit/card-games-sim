using card_games_sim.Cards;
using card_games_sim.Utils;

namespace card_games_sim.Interfaces;

public interface IShuffler
{
  public void ShuffleCards(Deck deck)
  {
    DeckManager.ShuffleCards(deck);
  }
}
