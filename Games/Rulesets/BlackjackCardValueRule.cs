namespace card_games_sim.Games.Rulesets;

public class BlackjackCardValueRule
{
  public int GetCardValue(PokerCard card)
  {
    if (card is PokerNumericCard number)
      return number.Value;

    if (card is PokerFaceCard face)
      return face.Rank == PokerFaceCard.FaceRank.Ace ? 11 : 10;

    if (card is JokerPokerCard)
      throw new Exception("Jokers aren't a valid card in blackjack");

    throw new ArgumentException("Unknown card type");
  }
}
