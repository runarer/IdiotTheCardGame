using IdiotGameCore.Model;

namespace IdiotGameCore.Tests.Model.Tests;

public class GameOptionsTest
{
    [Theory]
    [InlineData(2, 1, false)]
    [InlineData(5, 2, true)]
    [InlineData(8, 3, true)]
    [InlineData(6, 1, true)]
    public void GameOptions_CreateAGameWithValidInput_ObjectCreated(int players, int decks, bool joker)
    {

        // Action
        GameOptions gameOptions = new(players, decks, joker);

        // Assert
        Assert.Equal(players, gameOptions.PlayerNumber);
        Assert.Equal(decks, gameOptions.DeckNumber);
        Assert.Equal(joker, gameOptions.Joker);
    }

    [Fact]
    public void GameOptions_CreateAGameWithToFewPlayers_ThrowsInvalidOperationsException()
    {
        Assert.Throws<InvalidOperationException>(() => new GameOptions(1, 1, false));
    }

    [Fact]
    public void GameOptions_CreateAGameWithToManyPlayers_ThrowsInvalidOperationsException()
    {
        Assert.Throws<InvalidOperationException>(() => new GameOptions(9, 3, false));
    }

    [Fact]
    public void GameOptions_CreateAGameWithToFewDecks_ThrowsInvalidOperationsException()
    {
        Assert.Throws<InvalidOperationException>(() => new GameOptions(4, 0, false));
    }

    [Fact]
    public void GameOptions_CreateAGameWithToManyDecks_ThrowsInvalidOperationsException()
    {
        Assert.Throws<InvalidOperationException>(() => new GameOptions(2, 4, false));
    }


    [Theory]
    [InlineData(7, 1, true)]
    [InlineData(6, 1, false)]
    public void GameOptions_CreateAGameWithToFewDecksForNumberOfPlayers_ThrowsInvalidOperationsException(int players, int decks, bool joker)
    {
        Assert.Throws<InvalidOperationException>(() => new GameOptions(players, decks, joker));
    }

}

