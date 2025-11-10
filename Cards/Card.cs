namespace card_games_sim.Cards;

public class Card
{
  public bool FaceUp { get; set; } = true;
  public abstract string Name { get; }
}
