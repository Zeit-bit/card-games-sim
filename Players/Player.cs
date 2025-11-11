using card_games_sim.Cards;
using card_games_sim.Games;

namespace card_games_sim.Players;

public abstract class Player
{
  private string _name;
  public string Name
  {
    get { return _name; }
    set
    {
      if (string.IsNullOrWhiteSpace(value))
        throw new Exception("Can't have a blank name");
      _name = value;
    }
  }
  public List<Card> Hand { get; private init; } = new List<Card>();

  public Player(string name)
  {
    Name = name;
  }

  public abstract void Play(Game game);

  public void AddCardToHand(Card card)
  {
    Hand.Add(card);
  }
}
