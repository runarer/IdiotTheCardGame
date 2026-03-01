namespace IdiotGameCore.Model;

public class Game(GameOptions options)
{
    public async Task<bool> PlayCard(Player player, Card card)
    {
        return true;
    }

    public async Task Withdraw(Player player) { }

    public async Task<bool> EndTurn(Player player) { return true; }
}