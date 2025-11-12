using card_games_sim.Cards;
using card_games_sim.Games;
using card_games_sim.Interfaces;
using card_games_sim.Utils;

namespace card_games_sim.Players;

public class UnoPlayer : Player, IShuffler, IDealer
{
  public UnoPlayer(string name)
    : base(name) { }

  public override void Play(Game game)
  {
    throw new NotImplementedException();
  }

  public void DealCards(int qtyToDeal, Deck deck, Player[] players)
  {
    DeckManager.DealCards(qtyToDeal, deck, players);
  }

  public void ShuffleCards(Deck deck)
  {
    DeckManager.ShuffleCards(deck);
  }
}
