namespace card_games_sim.Cards;

public abstract class Card
{
  public bool FaceUp { get; set; } = true;
  public abstract string Name { get; }

  public override string ToString()
  {
    return Name;
  }
}
