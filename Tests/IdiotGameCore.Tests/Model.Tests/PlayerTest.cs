using IdiotGameCore.Model;

namespace IdiotGameCore.Tests.Model.Tests;

public class PlayerTest
{
    // Create and test Deck first so we can use it in these tests!



    // This class is to make sure we test the Playerclass and not the game.
    private class Game()
    {
        public async Task<bool> PlayCard(Player player, Card card) => true;
        public async Task Withdraw(Player player) { }
        public async Task<bool> EndTurn(Player player) => true;
    }

}
