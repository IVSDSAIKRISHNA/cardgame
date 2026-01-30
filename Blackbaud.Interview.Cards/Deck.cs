using System;

namespace Blackbaud.Interview.Cards;

/// <summary>
/// A deck of cards
/// </summary>
public class Deck
{
    private readonly Stack<Card> _stackOfCards;
    private static readonly Random _random = new Random();

    /// <summary>
    /// Private constructor for a new deck of <paramref name="cards"/>.
    /// Use Deck.NewDeck() static factory method.
    /// </summary>
    /// <param name="cards"></param>
    private Deck(IEnumerable<Card> cards)
    {
        _stackOfCards = new Stack<Card>(cards);
    }

    /// <summary>
    /// Creates and returns a new deck of cards.
    /// </summary>
    /// <returns></returns>
    public static Deck NewDeck(int numberOfDecks=1)
    {   
        /* return new  Deck(
             Enum.GetValues<Suit>().SelectMany(suit =>
                 Enum.GetValues<Rank>().Select(rank =>
                     new Card(rank, suit))
         ));*/

        if (numberOfDecks <= 0)
            throw new ArgumentException("Number of decks must be greater than zero.");

        var cards = new List<Card>();
        for (int d = 0; d < numberOfDecks; d++)
        {
            cards.AddRange(Enum.GetValues<Suit>().SelectMany(
                suit => Enum.GetValues<Rank>().Select(rank => new Card(rank, suit))
            ));
        }

        return new Deck(cards);
    }

    /// <summary>
    /// The number of remaining cards in the deck
    /// </summary>
    public int RemainingCards => _stackOfCards.Count;

    /// <summary>
    /// Returns true if there are no remaining cards in the deck
    /// </summary>
    public bool Empty => RemainingCards == 0;

    /// <summary>
    /// Removes the next card from the deck.
    /// </summary>
    /// <returns>The next card from the deck.
    /// Returns null if no cards remain.</returns>
    public Card NextCard()
    {
        if (!Empty)
        {
            var nextCard = _stackOfCards.Pop();
            return nextCard;
        }
        else
        {
            return null;
        }
    }

    public void Shuffle(int times = 1)
    {
        if (times <= 0) throw new ArgumentException("Shuffle times must be > 0");

        for (int t = 0; t < times; t++)
        {
            var cards = _stackOfCards.ToList();
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }

            _stackOfCards.Clear();
            foreach (var card in cards)
                _stackOfCards.Push(card);
        }
    }

}
