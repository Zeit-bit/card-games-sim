using card_games_sim.Cards;
using card_games_sim.Games.Rulesets;
using card_games_sim.Players;
using card_games_sim.Utils;

namespace card_games_sim.Games;

public class BlackjackGame : Game
{
  private BlackjackPlayer[] _players;
  public override Player[] Players
  {
    get { return _players; }
    init
    {
      if (value.Length <= 0)
        throw new Exception("A minimum of 1 player is necessary");
      if (value.Length > 8)
        throw new Exception("There can only be up to 8 players");

      _players = (BlackjackPlayer[])value;
    }
  }
  private BlackjackDealer Dealer { get; init; }
  private readonly int _rounds;
  private int Rounds
  {
    get { return _rounds; }
    init
    {
      if (value < 1)
        throw new Exception("A minimum of 1 round is required");
      _rounds = value;
    }
  }
  private int CurrentRound { get; set; }
  public Deck Deck { get; set; }

  public BlackjackCardValueRule RuleSet { get; private init; }

  public BlackjackGame(int rounds, BlackjackPlayer[] players)
    : this(rounds, players, DeckManager.CreateStandardPokerDeck()) { }

  public BlackjackGame(int rounds, BlackjackPlayer[] players, Deck deck)
  {
    Rounds = rounds;
    Players = players;
    Dealer = new BlackjackDealer("Dealer");
    CurrentRound = 1;
    RuleSet = new BlackjackCardValueRule();
    Deck = deck;
  }

  public override void Start()
  {
    while (CurrentRound <= Rounds)
    {
      Console.WriteLine($"----------Round: {CurrentRound}----------");
      Dealer.ShuffleCards(Deck);
      Dealer.DealCards(2, Deck, Players);
      foreach (var player in Players)
      {
        player.Play(this);
      }
      Dealer.Play(this);
      RoundPayout();
      Dealer.RetriveCards(Deck, Players);
      CurrentRound++;
      Console.WriteLine();
    }
    ShowWinner();
  }

  private void RoundPayout()
  {
    Console.WriteLine("----------Assigning payouts----------");
    foreach (var player in (BlackjackPlayer[])Players)
    {
      if (player.HandValue > 21)
      {
        Console.WriteLine($"{player.Name} busted");
        continue;
      }
      if (Dealer.HandValue > player.HandValue && Dealer.HandValue <= 21)
      {
        Console.WriteLine($"{player.Name} loses the round");
        continue;
      }
      if (Dealer.HandValue == player.HandValue)
      {
        Console.WriteLine($"{player.Name} ties with Dealer");
        continue;
      }
      if (Dealer.HandValue > 21 && player.HandValue < 21)
        player.Victories++;
      if (player.HandValue > Dealer.HandValue)
        player.Victories++;
      Console.WriteLine($"{player.Name} wins the round");
    }
  }

  private void ShowWinner()
  {
    var winners = new List<BlackjackPlayer>();
    int maxVictoryCount = -1;
    foreach (var player in (BlackjackPlayer[])Players)
    {
      if (player.Victories < maxVictoryCount)
        continue;
      if (player.Victories > maxVictoryCount)
      {
        winners.Clear();
        maxVictoryCount = player.Victories;
        winners.Add(player);
        continue;
      }
      winners.Add(player);
    }

    Console.WriteLine("----------Winners:----------");

    if (maxVictoryCount == 0)
    {
      Console.WriteLine("There are no winners");
      return;
    }

    foreach (var winner in winners)
    {
      Console.WriteLine($"{winner.Name} -> {winner.Victories} wins");
    }
  }
}
