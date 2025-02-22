using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards.Blue
{
    public class Dynamite(Deck deck) : Card("Dynamite", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            Utility.WriteColoredLine("\n{" + player.Name + "} USED DYNAMITE!", ConsoleColor.Yellow);
            player.PassiveCards.Add(this);
            player.Hand.Remove(this);
        }

        public void Explode(Player currentOwner, List<Player> targets)
        {
            int chance = new Random().Next(8);
            if (chance == 0)
            {
                Utility.WriteColoredLine("Dynamite exploded on " + currentOwner.Name + "!", ConsoleColor.DarkBlue);
                currentOwner.Lives -= 3;
                deck.DiscardedCards.Add(this);
                currentOwner.PassiveCards.Remove(this);
            }
            else
            {
                int nextPlayerIndex = (targets.IndexOf(currentOwner) + targets.Count - 1) % targets.Count;
                while (!targets.ElementAt(nextPlayerIndex).IsAlive)
                {
                    if (nextPlayerIndex == 0)
                    {
                        nextPlayerIndex = targets.Count - 1;
                    }
                    else
                    {
                        nextPlayerIndex--;
                    }
                }
                Utility.WriteColoredLine("Dynamite is going to " + targets.ElementAt(nextPlayerIndex).Name, ConsoleColor.DarkBlue);
                targets.ElementAt(nextPlayerIndex).PassiveCards.Add(this);
                currentOwner.PassiveCards.Remove(this);
            }
        }
    }
}
