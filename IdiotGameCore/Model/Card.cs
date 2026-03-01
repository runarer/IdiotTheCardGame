namespace IdiotGameCore.Model;

public record struct Card
{
    public readonly int Id => Deck * 1000 + (int)Suit * 100 + (int)Value;
    public Suits Suit;
    public Values Value;
    public int Deck;

    public Card(Suits suit, Values value, int deck)
    {
        // If this happens it's programmer skill issues!, should not be set by user input
        if ((suit == Suits.Joker && value != Values.Joker) || (suit != Suits.Joker && value == Values.Joker))
            throw new InvalidOperationException($"Value: {value} and Suit: {suit} did not match for Joker");

        Suit = suit;
        Value = value;
        Deck = deck;
    }

}

public enum Suits { Heart = 1, Diamond = 2, Spade = 3, Club = 4, Joker = 5 }

public enum Values
{
    Ace = 14,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13,
    Joker = 15
}