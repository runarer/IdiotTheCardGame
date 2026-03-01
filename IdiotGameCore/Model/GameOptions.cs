
namespace IdiotGameCore.Model;

public record GameOptions
{
    public const int MaxPlayer = 8;
    public const int MaxDecks = 3;
    public const int MinPlayers = 2;
    public const int MinDecks = 1;
    public int PlayerNumber;
    public int DeckNumber;
    public bool Joker;

    public GameOptions(int playerNumber, int decks, bool joker = false)
    {
        Joker = joker;

        // Validate player number
        if (playerNumber < MinPlayers || playerNumber > MaxPlayer)
            throw new InvalidOperationException($"Unaccepted number of players :{playerNumber}, need to be between 1 and {MaxPlayer}!");

        PlayerNumber = playerNumber;

        // Validate number of decks        
        if (decks < MinDecks || decks > MaxDecks)
            throw new InvalidOperationException($"Unaccepted number of decks :{decks}, need to be between 1 and {MaxDecks}!");
        if (decks * (joker ? 54 : 52) < playerNumber * 9)
            throw new InvalidOperationException("Not enough cards for the number of players!");

        DeckNumber = decks;
    }
}
