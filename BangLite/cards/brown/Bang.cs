using BangLite.Cards.Blue;
using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards.Brown
{
    public class Bang(Deck deck) : Card("Bang", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            Player target = GetTargets(player, targets);
            bool blocked = false;
            Utility.WriteColoredLine("\n{" + player.Name + "}: USED BANG ON " + target.Name, ConsoleColor.Yellow);

            foreach (Card card in target.PassiveCards)
            {
                if (card is Barrel barrel)
                {
                    blocked = barrel.Block();
                    break;
                }
            }

            if (!blocked)
            {
                foreach (Card card in target.Hand)
                {
                    if (card is Missed missed)
                    {
                        blocked = missed.Miss(target);
                        break;
                    }
                }
            }

            if (!blocked)
            {
                target.Lives--;
            }
            RemoveCard(player);
        }
    }
}
