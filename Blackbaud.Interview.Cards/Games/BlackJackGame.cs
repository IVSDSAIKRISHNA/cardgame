using CardGameExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackbaud.Interview.Cards.Games;
public class BlackJackGame : IGame
{
    private readonly Deck _deck;
    private readonly CardDistributor _distributor;
    private readonly List<Player> _players;
    private readonly int _cardsPerPlayer = 2;

    public BlackJackGame(IEnumerable<string> playerNames, int decks = 6)
    {
        _deck = Deck.NewDeck(decks);
        _deck.Shuffle(3);
        _distributor = new CardDistributor();

        _players = new List<Player>();
        foreach (var name in playerNames)
            _players.Add(new Player(name));
    }

    public void StartGame()
    {
        Console.WriteLine($"Starting Blackjack with {_players.Count} players and {_deck.RemainingCards} cards.");
        _distributor.DealCards(_deck, _players, _cardsPerPlayer);
        PrintHands();
    }

    private void PrintHands()
    {
        for (int i = 0; i < _players.Count; i++)
        {
            Console.WriteLine($"Player {_players[i].Name}:");
            foreach (var card in _players[i].Hand)
                Console.WriteLine($"{card.ToShortString()} - {card}");
            Console.WriteLine();
        }

        Console.WriteLine($"Cards remaining in deck: {_deck.RemainingCards}");
        Console.WriteLine("------------------------------------------------");
    }

    // Add a new player mid-game
    public void AddPlayer(string playerName)
    {
        var newPlayer = new Player(playerName);
        _players.Add(newPlayer);

        Console.WriteLine($"Adding new player {playerName} mid-game...");

        // Deal initial cards to new player only
        _distributor.DealCards(_deck, new List<Player> { newPlayer }, _cardsPerPlayer);

        PrintHands();
    }
}
