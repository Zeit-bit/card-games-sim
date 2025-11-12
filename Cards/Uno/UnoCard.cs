using card_games_sim.Games;

namespace card_games_sim.Cards.Uno;

public abstract class UnoCard : Card
{
  public enum UnoCardColors
  {
    Red,
    Green,
    Blue,
    Yellow,
    Wild,
  }

  public enum UnoCardSymbols
  {
    Number,
    Skip,
    Reverse,
    Draw,
    Wild,
  }

  public int? Value { get; set; } = null;

  public UnoCardColors CardColor { get; set; }
  public UnoCardSymbols CardSymbol { get; init; }

  protected UnoCard(UnoCardColors color)
  {
    CardColor = color;
  }

  public abstract void Play(UnoGame game);

  public void DiscardCard(UnoGame game)
  {
    var currentPlayer = game.Players[game.CurrentPlayerIndex];
    Console.WriteLine($"{currentPlayer.Name} plays {Name}");
    currentPlayer.Hand.Remove(this);
    game.DiscardPile.Cards.Push(this);
  }
}
