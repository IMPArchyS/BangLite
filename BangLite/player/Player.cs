using BangLite.Cards;

namespace BangLite.Players
{
    public class Player
    {
        public List<Card> Hand { get; private set; } = new();
        public int Lives { get; set; } = 4;
        public string Name { get; private set; } = "unknown";
        public bool IsAlive { get; private set; } = true;
        public Player(string name)
        {
            Name = name;
        }
    }
}
