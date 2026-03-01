namespace IdiotGameCore.Model;

public record struct Card(Suits Suit, Values Value, int Deck)
{
    public readonly int Id => Deck*1000 + (int)Suit*100 + (int)Value;
}

public enum Suits { Heart, Diamond, Spade, Club }

public enum Values { 
    One = 14, 
    Two = 2, 
    Three = 3, 
    Four = 4, 
    Five = 5, 
    Six = 6, 
    Seven = 7, 
    Eight = 8, 
    Nine = 9, 
    Ten = 10, 
    Jack = 11 , 
    Queen = 12, 
    King = 13, 
    Joker = 15
}