using IdiotGameCore.Model;
using IdiotGameCore.Interfaces;

namespace IdiotGameCore.Tests.Model.Tests;

public class PlayerTest
{
    // Create and test Deck first so we can use it in these tests!

    public async Task PlayCardFromHand()
    {

    }

    public async Task PlayCardFromTopTable()
    {

    }

    public async Task PlayCardFromBottomTable_GotCardInHandAndTopFacingCards_ReturnNull()
    {

    }

    public async Task PlayCardFromBottomTable_GotCardInHandButNotTopFacingCards_ReturnNull()
    {

    }


    public async Task PlayCardFromBottomTable_GotNoCardsInHandButTopFacingCards_ReturnNull()
    {

    }
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public async Task PlayCardFromBottomTable_GotNoCardsInHandAndNoTopFacingCards_ReturnCard(int stack)
    {
        var player = new Player("Tester", new Game());
        var deck = new CardDeck(1, 0);
        var drawCard = deck.DrawCard();
        Assert.NotNull(drawCard);
        Card card = (Card)drawCard;

        player.BottomTableCards[stack] = card;
        var playedCard = await player.PlayCardFromBottomTable(stack);

        Assert.NotNull(playedCard);
        Assert.Equal(card, playedCard);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public async Task PlayCardFromBottomTable_GotNoCardsInHandAndNoTopFacingCardsAndNoMoreBottomCards_ReturnNull(int stack)
    {
        var player = new Player("Tester", new Game());

        Assert.Null(await player.PlayCardFromBottomTable(stack));
    }

    // This class is to make sure we test the Playerclass and not the game.
    private class Game() : IGame
    {
        public async Task<bool> PlayCard(Player player, Card card) => true;
        public async Task Withdraw(Player player) { }
        public async Task<bool> EndTurn(Player player) => true;
    }

}
