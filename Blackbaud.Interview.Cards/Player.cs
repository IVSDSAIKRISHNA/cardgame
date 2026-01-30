using Blackbaud.Interview.Cards;
using System.Collections.Generic;

namespace CardGameExample;

public class Player
{
    public string Name { get; set; }
    public List<Card> Hand { get; } = new List<Card>();

    public Player(string name)
    {
        Name = name;
    }
}
