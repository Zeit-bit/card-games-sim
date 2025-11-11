using card_games_sim.Games;

namespace card_games_sim.Players;

public class BlackjackPlayer : Player
{
  public BlackjackPlayer(string name)
    : base(name) { }

  public int Victories { get; set; }
  public int HandValue { get; private set; }

  public int CalculateHandValue(ICardValueRule rule)
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
    return HandValue;
  }
    
  public override void Play(Game game)
  {
    throw new NotImplementedException();
  }
}
