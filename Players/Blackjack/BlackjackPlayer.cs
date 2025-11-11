using card_games_sim.Cards;
using card_games_sim.Games;

namespace card_games_sim.Players;

public class BlackjackPlayer : Player
{
  public BlackjackPlayer(string name)
    : base(name) { }

  public int Victories { get; set; }
  public int Value { get; private set; }
  protected bool ShouldPlay { get; set; } = true;

  public override void Play(Game game)
  {
    while (ShouldPlay)
    {
      if (Value > 21)
      {
        Console.WriteLine($"{Name} busted");
        break;
      }

      int rnd = Random.Shared.Next(0, 2);
      if (rnd == 0)
        Hit(((BlackjackGame)game).Deck);
      else
      {
        Stand();
      }
    }
    ShouldPlay = true;
  }

  protected void Play(int pointOfCut, Game game)
  {
    while (ShouldPlay)
    {
      if (Value > 21)
      {
        Console.WriteLine($"{Name} busted");
        break;
      }
      if (Value >= pointOfCut)
      {
        Stand();
        break;
      }
      Hit(((BlackjackGame)game).Deck);
    }
    ShouldPlay = true;
  }

  protected void Hit(Deck deck)
  {
    Console.WriteLine($"{Name} hits");
    AddCardToHand(deck.Cards.Pop());
  }

  protected void Stand()
  {
    Console.WriteLine($"{Name} stands");
    ShouldPlay = false;
  }
}
