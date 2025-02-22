using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards
{
    public abstract class Card
    {
        public string Name { get; private set; }
        protected Deck deck;

        public Card(string name, Deck deck)
        {
            Name = name;
            this.deck = deck;
        }

        public abstract void UseCard(Player player, List<Player> targets);

        public Player GetTargets(Player currentPlayer, List<Player> targets)
        {
            Utility.WriteColoredLine("\nPossible Targets: ", ConsoleColor.White);
            int index = 1;
            foreach (Player player in targets)
            {
                if (!currentPlayer.Equals(player))
                {
                    Utility.WriteColoredLine(index + ". " + player.Name + " {" + player.Lives + "}", ConsoleColor.DarkRed);
                }
                index++;
            }
            while (true)
            {
                Utility.WriteColored("Choose target: ", ConsoleColor.White);
                int indexOfTarget = Utility.InputInt() - 1;
                if (indexOfTarget < 0 || indexOfTarget > targets.Count - 1)
                {
                    Console.WriteLine("Out of bounds input! Try again...");
                }
                else if (targets.ElementAt(indexOfTarget).Equals(currentPlayer))
                {
                    Console.WriteLine("Can't target yourself! Try again...");
                }
                else if (!targets.ElementAt(indexOfTarget).IsAlive)
                {
                    Console.WriteLine("Can't target the dead! Try again...");
                }
                else
                {
                    return targets.ElementAt(indexOfTarget);
                }
            }
        }

        public void RemoveCard(Player player)
        {
            deck.DiscardedCards.Add(this);
            player.Hand.Remove(this);
        }
    }
}
