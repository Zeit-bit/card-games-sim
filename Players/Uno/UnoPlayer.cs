using card_games_sim.Cards;
using card_games_sim.Cards.Uno;
using card_games_sim.Games;
using card_games_sim.Interfaces;
using card_games_sim.Utils;

namespace card_games_sim.Players;

public class UnoPlayer : Player, IShuffler, IDealer
{
  public bool Blocked { get; set; }

  public UnoPlayer(string name)
    : base(name) { }

  public override void Play(Game game)
  {
    Console.WriteLine();
    Console.WriteLine($"----------{Name}'s turn----------");
    if (Blocked)
    {
      Console.WriteLine("Turn blocked");
      Blocked = false;
      return;
    }

    Console.WriteLine($"Cards: {string.Join(", ", Hand)}");

    UnoGame unoGame = (UnoGame)game;
    var cardToMatch = (UnoCard)unoGame.DiscardPile.Cards.Peek();
    Console.WriteLine($"Card in the discardPile: {cardToMatch}");
    var matchingCards = GetMatchingCardsFromHand(cardToMatch, unoGame);

    if (VictimToDrawCard(matchingCards, cardToMatch, unoGame))
      return;

    var cardToPlay = SelectCard((UnoCard[])matchingCards, unoGame);
    if (cardToPlay is null)
    {
      Console.WriteLine($"{Name} draws a card");
      var cardDrawed = DrawFromPile(unoGame);
      if (ShouldPlayDrawedCard(cardDrawed, cardToMatch, unoGame))
        cardDrawed.Play(unoGame);
      return;
    }

    cardToPlay.Play(unoGame);
  }

  protected virtual bool ShouldPlayDrawedCard(UnoCard cardDrawed, UnoCard cardToMatch, UnoGame game)
  {
    if (CardMatches(cardDrawed, cardToMatch, game))
      return true;
    return false;
  }

  protected bool VictimToDrawCard(UnoCard[] matchingCards, UnoCard cardToMatch, UnoGame unoGame)
  {
    if (
      matchingCards.Length == 0
      && cardToMatch.CardSymbol == UnoCard.UnoCardSymbols.Draw
      && unoGame.AccumulatedDrawCount > 0
    )
    {
      Console.WriteLine($"{Name} draws {unoGame.AccumulatedDrawCount} cards");
      for (int i = 0; i < unoGame.AccumulatedDrawCount; i++)
      {
        DrawFromPile(unoGame);
      }
      unoGame.AccumulatedDrawCount = 0;
      return true;
    }
    return false;
  }

  protected UnoCard[] GetMatchingCardsFromHand(UnoCard cardToMatch, UnoGame game)
  {
    return Hand.OfType<UnoCard>().Where(card => CardMatches(card, cardToMatch, game)).ToArray();
  }

  protected bool CardMatches(UnoCard card, UnoCard cardToMatch, UnoGame game)
  {
    if (
      card.CardSymbol != UnoCard.UnoCardSymbols.Draw
      && cardToMatch.CardSymbol == UnoCard.UnoCardSymbols.Draw
      && game.AccumulatedDrawCount > 0
    )
      return false;

    if (card.CardColor == cardToMatch.CardColor || card.CardSymbol == UnoCard.UnoCardSymbols.Wild)
      return true;

    if (card.CardSymbol == UnoCard.UnoCardSymbols.Number && cardToMatch.Value == card.Value)
      return true;

    if (
      card.CardSymbol == cardToMatch.CardSymbol
      && card.CardSymbol != UnoCard.UnoCardSymbols.Number
    )
      return true;

    return false;
  }

  protected UnoCard DrawFromPile(UnoGame unoGame)
  {
    if (unoGame.DrawPile.Cards.Count == 0)
    {
      unoGame.DrawPile = unoGame.DiscardPile;
      unoGame.DiscardPile.Cards.Clear();
      ShuffleCards(unoGame.DrawPile);
    }
    var drawedCard = (UnoCard)unoGame.DrawPile.Cards.Pop();
    AddCardToHand(drawedCard);
    return drawedCard;
  }

  protected virtual UnoCard? SelectCard(UnoCard[] matchingCards, UnoGame game)
  {
    if (matchingCards.Length == 0)
      return null;

    int rndIndex = Random.Shared.Next(0, matchingCards.Length);
    return matchingCards[rndIndex];
  }

  public void DealCards(int qtyToDeal, Deck deck, Player[] players)
  {
    Console.WriteLine($"{Name} deals the cards");
    DeckManager.DealCards(qtyToDeal, deck, players);
  }

  public void ShuffleCards(Deck deck)
  {
    DeckManager.ShuffleCards(deck);
  }
}
