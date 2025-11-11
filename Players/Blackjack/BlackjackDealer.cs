using card_games_sim.Cards;
using card_games_sim.Games;
using card_games_sim.Interfaces;
using card_games_sim.Utils;

namespace card_games_sim.Players;

public class BlackjackDealer : BlackjackPlayer, IShuffler, IDealer
{
  public BlackjackDealer(string name)
    : base(name)
  {
    PointOfCut = 17;
  }

  private int PointOfCut { get; set; }
  public Card Upcard
  {
    get { return Hand.First(card => card.FaceUp == true); }
  }

  public override void Play(Game game)
  {
    Play(PointOfCut, game);
  }

  public void ShuffleCards(Deck deck)
  {
    Console.WriteLine($"{Name} shuffles the cards");
    DeckManager.ShuffleCards(deck);
  }

  public void DealCards(int qtyToDeal, Deck deck, Player[] players)
  {
    Console.WriteLine($"{Name} deals the cards");
    AddCardToHand(deck.Cards.Pop());
    AddCardToHand(deck.Cards.Pop());
    Hand[1].FaceUp = false;

    DeckManager.DealCards(qtyToDeal, deck, players);
  }

  public void RetriveCards(Deck deck, Player[] players)
  {
    Console.WriteLine($"{Name} retrieves the cards");
    foreach (var card in Hand)
    {
      if (card.FaceUp == false)
        card.FaceUp = true;
      deck.Cards.Push(card);
    }
    foreach (var player in players)
    {
      foreach (var card in player.Hand)
      {
        deck.Cards.Push(card);
      }
    }
  }
}
