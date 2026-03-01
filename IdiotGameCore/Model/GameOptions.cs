
namespace IdiotGameCore.Model;

public record GameOptions
{
    public static readonly int MAX_PLAYERS = 8;
    public static readonly int MAX_DECKS = 3;
    public int PlayerNumber;
    public int DeckNumber;
    public bool Joker;

    public GameOptions(int playerNumber, int decks, bool joker = false)
    {
        Joker = joker;

        // Validate player number
        if (playerNumber < 1 || playerNumber > MAX_PLAYERS)
            throw new InvalidOperationException($"Unaccepted number of players :{playerNumber}, need to be between 1 and {MAX_PLAYERS}!");

        PlayerNumber = playerNumber;

        // Validate number of decks        
        if (decks < 1 || decks > MAX_DECKS)
            throw new InvalidOperationException($"Unaccepted number of decks :{decks}, need to be between 1 and {MAX_DECKS}!");
        if (decks * (joker ? 54 : 52) < playerNumber * 9)
            throw new InvalidOperationException("Not enough cards for the number of players!");

        DeckNumber = decks;
    }
}
