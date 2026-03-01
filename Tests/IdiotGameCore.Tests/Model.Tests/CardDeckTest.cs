using IdiotGameCore.Model;

namespace IdiotGameCore.Tests.Model.Tests;

public class CardDeckTest
{
    [Theory]
    [InlineData(1, 0, 52)]
    [InlineData(2, 0, 104)]
    [InlineData(1, 2, 54)]
    [InlineData(3, 2, 162)]
    public void Deck_CreateDeck_DeckCreatedWithRightNumberOfUniqeCards(int decks, int jokers, int cardsExpected)
    {
        CardDeck deck = new(decks, jokers);

        Assert.Equal(cardsExpected, deck.Count);
        var deckUnique = GetAllCards(deck);
        Assert.Equal(cardsExpected, deckUnique.Count);
    }

    [Theory]
    [InlineData(1, 0, Suits.Diamond, Values.Ace, 1)]
    [InlineData(2, 1, Suits.Joker, Values.Joker, 2)]
    [InlineData(3, 0, Suits.Heart, Values.Ten, 3)]
    [InlineData(3, 2, Suits.Heart, Values.Ten, 3)]
    [InlineData(3, 2, Suits.Joker, Values.Joker, 3)]
    public void Deck_CreateDeck_DeckCreatedAndContainsTheseCards(int decks, int jokers, Suits suitOfExpectedCard, Values valueOfExpectedCard, int deckOfExpectedCard)
    {
        Card expectedCardInDeck = new(suitOfExpectedCard, valueOfExpectedCard, deckOfExpectedCard);

        CardDeck deck = new(decks, jokers);


        var deckUnique = GetAllCards(deck);
        Assert.Contains(expectedCardInDeck, deckUnique);
    }

    private static HashSet<Card> GetAllCards(CardDeck deck)
    {
        HashSet<Card> cards = [];

        while (deck.Count > 0)
        {
            var card = deck.DrawCard();
            if (card is null)
                break;
            cards.Add((Card)card);
        }

        return cards;
    }
}
