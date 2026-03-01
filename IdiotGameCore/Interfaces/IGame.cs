using IdiotGameCore.Model;

namespace IdiotGameCore.Interfaces;

public interface IGame
{
    public Task<bool> PlayCard(Player player, Card card);

    public Task Withdraw(Player player);

    public Task<bool> EndTurn(Player player);
}
