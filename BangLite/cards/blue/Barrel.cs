using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards.Blue
{
    public class Barrel(Deck deck) : Card("Barrel", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            foreach (Card card in player.PassiveCards)
            {
                if (card is Barrel)
                {
                    Utility.WriteColoredLine("Barrel is already active!", ConsoleColor.Red);
                    return;
                }
            }

            Utility.WriteColoredLine(player.Name + " used Barrel!", ConsoleColor.Red);
            player.PassiveCards.Add(this);
            player.Hand.Remove(this);
        }

        public bool Block()
        {
            int chance = new Random().Next(4);
            if (chance == 0)
            {
                Utility.WriteColoredLine("Barrel blocked the shot!", ConsoleColor.Red);
                return true;
            }
            return false;
        }
    }
}
