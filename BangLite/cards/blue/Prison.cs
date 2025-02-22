using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards.Blue
{
    public class Prison(Deck deck) : Card("Prison", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            Player? target = null;
            bool escaped = true;
            if (!CheckForTargets(targets))
            {
                Utility.WriteColoredLine("No targets available!", ConsoleColor.Red);
                return;
            }

            while (true)
            {
                target = GetTargets(player, targets);
                foreach (Card card in target.PassiveCards)
                {
                    if (card is Prison)
                    {
                        Utility.WriteColoredLine(target.Name + " is already in Prison!", ConsoleColor.Red);
                        escaped = false;
                        break;
                    }
                }
                if (escaped)
                {
                    break;
                }
            }
            Utility.WriteColoredLine(player.Name + " used Prison on " + target.Name, ConsoleColor.Red);
            target.PassiveCards.Add(this);
            player.Hand.Remove(this);
        }

        public bool Escape(Player currentPrisoner)
        {
            int chance = new Random().Next(4);
            if (chance == 0)
            {
                Utility.WriteColoredLine(currentPrisoner.Name + " has escaped!", ConsoleColor.Red);
                deck.DiscardedCards.Add(this);
                currentPrisoner.PassiveCards.Remove(this);
                return true;
            }
            else
            {
                Utility.WriteColoredLine(currentPrisoner.Name + " has failed to escape!", ConsoleColor.Red);
                currentPrisoner.PassiveCards.Remove(this);
                return false;
            }
        }

        private bool CheckForTargets(List<Player> opponents)
        {
            int targetsAvailable = opponents.Count - 1;
            foreach (Player opponent in opponents)
            {
                foreach (Card card in opponent.PassiveCards)
                {
                    if (card is Prison)
                    {
                        targetsAvailable--;
                        break;
                    }
                }
            }
            return targetsAvailable > 0 ? true : false;
        }
    }
}
