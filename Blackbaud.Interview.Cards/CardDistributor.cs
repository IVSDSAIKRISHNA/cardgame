using Blackbaud.Interview.Cards;
using System;
using System.Collections.Generic;

namespace CardGameExample;

public class CardDistributor
{
    // Deal a specific number of cards to each player
    public void DealCards(Deck deck, List<Player> players, int cardsPerPlayer)
    {
        if (deck == null) throw new ArgumentNullException(nameof(deck));
        if (players == null || players.Count == 0) throw new ArgumentException("At least one player is required.");
        if (cardsPerPlayer <= 0) throw new ArgumentException("Cards per player must be > 0");
        if (deck.RemainingCards < players.Count * cardsPerPlayer)
            throw new InvalidOperationException("Not enough cards in the deck.");

        for (int round = 0; round < cardsPerPlayer; round++)
        {
            foreach (var player in players)
            {
                var card = deck.NextCard();
                player.Hand.Add(card);
            }
        }
    }
}
