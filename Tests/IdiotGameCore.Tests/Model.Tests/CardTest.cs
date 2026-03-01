using IdiotGameCore.Model;

namespace IdiotGameCore.Tests.Model.Tests;

public class CardTest
{

    [Theory]
    [InlineData(Suits.Diamond, Values.Ace, 1, 1214)]
    [InlineData(Suits.Heart, Values.King, 2, 2113)]
    [InlineData(Suits.Club, Values.Two, 1, 1402)]
    [InlineData(Suits.Spade, Values.Ten, 1, 1310)]
    [InlineData(Suits.Joker, Values.Joker, 1, 1515)]
    public void Card_CreateValidCards_ShouldBeCreatedWithAValueAdded(Suits suit, Values value, int deck, int id)
    {

        Card card = new(suit, value, deck);

        Assert.Equal(id, card.Id);
        Assert.Equal(suit, card.Suit);
        Assert.Equal(value, card.Value);
        Assert.Equal(deck, card.Deck);
    }

    [Theory]
    [InlineData(Suits.Joker, Values.Ace)]
    [InlineData(Suits.Heart, Values.Joker)]
    public void Card_CreateInvalidJokerCards_ThrowsInvalidOperationException(Suits suit, Values value)
    {
        Assert.Throws<InvalidOperationException>(() => new Card(suit, value, 1));
    }

}

