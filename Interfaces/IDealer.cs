using card_games_sim.Cards;
using card_games_sim.Players;
using card_games_sim.Utils;

namespace card_games_sim.Interfaces;

public interface IDealer
{
  public void DealCards(int qtyToDeal, Deck deck, Player[] players)
  {
    DeckManager.DealCards(qtyToDeal, deck, players);
  }
}
