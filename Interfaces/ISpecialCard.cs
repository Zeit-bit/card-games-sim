using System;
using card_games_sim.Games;

namespace card_games_sim.Interfaces;

public interface ISpecialCard
{
  void ApplySpecialEffect(Game game);
}
