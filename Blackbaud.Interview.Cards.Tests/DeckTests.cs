using Xunit;

namespace Blackbaud.Interview.Cards.Tests;
public class DeckTests
{
    [Fact]
    public void CanCreateANewDeck()
    {
        var deck = Deck.NewDeck();
        Assert.Equal(52, deck.RemainingCards);
    }
    [Fact]
    public void NewDeck_IsNotEmpty()
    {
        var deck = Deck.NewDeck();
        Assert.False(deck.Empty);
    }

    [Fact]
    public void NextCard_RemovesOneCardFromDeck()
    {
        var deck = Deck.NewDeck();

        var card = deck.NextCard();

        Assert.NotNull(card);
        Assert.Equal(51, deck.RemainingCards);
    }

    [Fact]
    public void DrawingAllCards_MakesDeckEmpty()
    {
        var deck = Deck.NewDeck();

        for (int i = 0; i < 52; i++)
        {
            deck.NextCard();
        }

        Assert.True(deck.Empty);
    }

    [Fact]
    public void NextCard_OnEmptyDeck_ReturnsNull()
    {
        var deck = Deck.NewDeck();

        for (int i = 0; i < 52; i++)
        {
            deck.NextCard();
        }

        var card = deck.NextCard();

        Assert.Null(card);
    }

    [Fact]
    public void Shuffle_DoesNotChangeCardCount()
    {
        var deck = Deck.NewDeck();
        deck.Shuffle(3);

        Assert.Equal(52, deck.RemainingCards);
    }

    [Fact]
    public void Shuffle_ChangesOrderOfCards()
    {
        var deck1 = Deck.NewDeck();
        var deck2 = Deck.NewDeck();

        deck2.Shuffle(1);

        var firstCardDeck1 = deck1.NextCard();
        var firstCardDeck2 = deck2.NextCard();

        Assert.NotEqual(firstCardDeck1.ToString(), firstCardDeck2.ToString());
    }

}
