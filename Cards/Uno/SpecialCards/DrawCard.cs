using card_games_sim.Games;

namespace card_games_sim.Cards.Uno.SpecialCards;

public class DrawCard : SpecialUnoCard
{
  private int _drawCount;
  private int DrawCount
  {
    get { return _drawCount; }
    set
    {
      if (value != 2 && value != 4)
        throw new Exception("There can only be +2 and +4 draw cards");
      _drawCount = value;
    }
  }
  private string GetColorString
  {
    get { return DrawCount == 2 ? CardColor.ToString() : ""; }
  }

  private UnoCardColors InitialColor { get; set; }

  public DrawCard(UnoCardColors color, int drawCount)
    : base(color, UnoCardSymbols.Draw)
  {
    DrawCount = drawCount;
    InitialColor = color;
  }

  public override string Name
  {
    get { return $"Draw +{DrawCount} {GetColorString}"; }
  }

  public override void ApplySpecialEffect(UnoGame game)
  {
    CardColor = InitialColor;

    if (CardColor == UnoCardColors.Wild)
    {
      int rnd = Random.Shared.Next(0, 4);
      var color = (UnoCardColors)rnd;
      CardColor = color;
      Console.WriteLine($"Choosing color: {color}");
    }
    game.AccumulatedDrawCount += DrawCount;
    Console.WriteLine($"Current accumulated draw count: {game.AccumulatedDrawCount}");
  }
}
