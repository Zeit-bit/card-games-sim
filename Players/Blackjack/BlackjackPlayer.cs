using card_games_sim.Cards;
using card_games_sim.Cards.Poker;
using card_games_sim.Games;
using card_games_sim.Games.Rulesets;
using card_games_sim.Interfaces;

namespace card_games_sim.Players;

public class BlackjackPlayer : Player
{
  public BlackjackPlayer(string name)
    : base(name) { }

  public int Victories { get; set; }
  public int HandValue { get; private set; }
  protected bool ShouldPlay { get; set; } = true;

  public void CalculateHandValue(ICardValueRule rule)
  {
    int total = 0;
    int aceCount = 0;

    foreach (var card in Hand)
    {
      if (card is not PokerCard pokerCard)
        throw new Exception("Blackjack solo usa PokerCards.");

      int value = rule.GetCardValue(pokerCard);
      total += value;

      //Ace counter for substraction if hand value is greater than 21
      if (pokerCard is PokerFaceCard face && face.Rank == PokerFaceCard.FaceRank.Ace)
        aceCount++;
    }

    while (total > 21 && aceCount > 0)
    {
      total -= 10;
      aceCount--;
    }

    HandValue = total;
  }

  public override void Play(Game game)
  {
    CalculateHandValue(((BlackjackGame)game).RuleSet);

    while (ShouldPlay)
    {
      if (HandValue > 21)
      {
        Console.WriteLine($"{Name} busted");
        break;
      }

      int rnd = Random.Shared.Next(0, 2);
      if (rnd == 0)
        Hit((BlackjackGame)game);
      else
      {
        Stand();
      }
    }
    ShouldPlay = true;
  }

  protected void Play(int pointOfCut, Game game)
  {
    CalculateHandValue(((BlackjackGame)game).RuleSet);

    while (ShouldPlay)
    {
      if (HandValue > 21)
      {
        Console.WriteLine($"{Name} busted");
        break;
      }
      if (HandValue >= pointOfCut)
      {
        Stand();
        break;
      }
      Hit((BlackjackGame)game);
    }
    ShouldPlay = true;
  }

  protected void Hit(BlackjackGame blackjackGame)
  {
    Console.WriteLine($"{Name} hits");
    AddCardToHand(blackjackGame.Deck.Cards.Pop());
    CalculateHandValue(blackjackGame.RuleSet);
  }

  protected void Stand()
  {
    Console.WriteLine($"{Name} stands");
    ShouldPlay = false;
  }
}
