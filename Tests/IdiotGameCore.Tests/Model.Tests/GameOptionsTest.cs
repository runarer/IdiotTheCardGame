using IdiotGameCore.Model;

namespace IdiotGameCore.Tests.Model.Tests;

public class GameOptionsTest
{
    [Theory]
    [InlineData(2, 1, false)]
    [InlineData(5, 2, true)]
    [InlineData(8, 3, true)]
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
        throw new NotImplementedException("Test not yet implemented");
    }

    [Fact]
    public void GameOptions_CreateAGameWithToManyPlayers_ThrowsInvalidOperationsException()
    {
        throw new NotImplementedException("Test not yet implemented");
    }

    [Fact]
    public void GameOptions_CreateAGameWithToFewDecks_ThrowsInvalidOperationsException()
    {
        throw new NotImplementedException("Test not yet implemented");
    }

    [Fact]
    public void GameOptions_CreateAGameWithToManyDecks_ThrowsInvalidOperationsException()
    {
        throw new NotImplementedException("Test not yet implemented");
    }

    [Fact]
    public void GameOptions_CreateAGameWithToFewDecksForNumberOfPlayers_ThrowsInvalidOperationsException()
    {
        throw new NotImplementedException("Test not yet implemented");
    }

}

