namespace IdiotGameCore.Model;

public class Player(string alias, Game game)
{
    public const int TableCardStacks = 3;
    private Game _game = game;
    public required string Alias { get; init; } = alias;
    public HashSet<Card> Hand { get; private set; } = [];
    public Card?[] BottomTableCards = new Card?[TableCardStacks];
    public Card?[] TopTableCards = new Card?[TableCardStacks];

    // public Player(string alias, Game game)
    // {
    //     Alias = alias;
    //     _game = game;
    // }

    /// <summary>
    /// Play a card fromt the hand.
    /// There are checks to make sure the player owns the card and it's in their hand.
    /// </summary>
    /// <param name="card">the card to be played</param>
    /// <returns></returns>
    public async Task<Card?> PlayCardFromHand(Card card)
    {
        if (Hand.Count < 1)
            return null;
        if (!Hand.Contains(card))
            return null;

        if (await _game.PlayCard(this, card))
        {
            Hand.Remove(card);
            return card;
        }

        return null;
    }

    /// <summary>
    /// Play a upwards facing card from the table. 
    /// Makes sure that the player has no cards in hand and 
    /// that there's a card at that index.
    /// </summary>
    /// <param name="tableStack">zero indexed number of the table stack to play from</param>
    /// <returns>null if action couldn't be completed otherwise the card played is returned.</returns>
    /// <exception cref="InvalidOperationException">
    /// This shouldn't happen and indicates wrong use of the method in your code.
    /// </exception>
    public async Task<Card?> PlayCardFromTopTable(int tableStack)
    {
        if (tableStack < 0 || tableStack >= TableCardStacks)
            throw new InvalidOperationException($"There is not a table stack with value {tableStack}");

        if (Hand.Count > 0)
            return null;

        if (TopTableCards[tableStack] is null)
            return null;

        if (await _game.PlayCard(this, (Card)TopTableCards[tableStack]!))
        {
            TopTableCards[tableStack] = null;
            return TopTableCards[tableStack];
        }

        return null;
    }

    /// <summary>
    /// Play a downwards facing card from the table.
    /// Makes sure that the player has no cards in hand, all upwards facing card
    /// are played and that there's a card at that index.
    /// </summary>
    /// <param name="tableStack">zero indexed number of the table stack to play from</param>
    /// <returns>null if action couldn't be completed otherwise the card played is returned.</returns>
    /// <exception cref="InvalidOperationException">
    /// This shouldn't happen and indicates wrong use of the method in your code.
    /// </exception>
    public async Task<Card?> PlayCardFromBottomTable(int tableStack)
    {
        if (tableStack < 0 || tableStack >= TableCardStacks)
            throw new InvalidOperationException($"There is not a table stack with value {tableStack}");

        if (Hand.Count > 0 || TopTableCards.Any(item => item is not null))
            return null;

        if (BottomTableCards[tableStack] is null)
            return null;

        if (await _game.PlayCard(this, (Card)BottomTableCards[tableStack]!))
        {
            TopTableCards[tableStack] = null;
            return TopTableCards[tableStack];
        }

        return null;
    }

    /// <summary>
    /// Signal that the player is done and wants to end the turn
    /// </summary>
    /// <returns>ending turn accepted by the game</returns>
    public async Task<bool> EndTurn()
    {
        return await _game.EndTurn(this);
    }

    /// <summary>
    /// Signal that the player withdrawes from the game
    /// </summary>
    /// <returns></returns>
    public async Task Withdraw()
    {
        await _game.Withdraw(this);
    }
}