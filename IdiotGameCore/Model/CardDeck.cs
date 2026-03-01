namespace IdiotGameCore.Model;

public class CardDeck
{
    private Queue<Card> _deck;

    public int Count => _deck.Count;

    public CardDeck(int numberOfDecks, int jokers)
    {
        int numberOfCards = numberOfDecks * 52 + numberOfDecks * jokers;

        Card[] cards = new Card[numberOfCards];

        int index = 0;
        for (int deckNumber = 1; deckNumber < numberOfDecks; deckNumber++)
        {
            foreach (var suit in Enum.GetValues<Suits>())
            {
                if (suit == Suits.Joker)
                    continue;
                foreach (var value in Enum.GetValues<Values>())
                {
                    if (value == Values.Joker)
                        continue;
                    cards[index++] = new Card(suit, value, deckNumber);
                }
            }
        }

        for (int joker = 1; index < numberOfCards; joker++)
        {
            cards[index++] = new Card(Suits.Joker, Values.Joker, joker);
        }

        _deck = new Queue<Card>(cards);
    }

    public Card? DrawCard()
    {
        return _deck.TryDequeue(out Card card) ? card : null;
    }
}