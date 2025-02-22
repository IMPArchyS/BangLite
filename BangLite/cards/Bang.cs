using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards
{
    public class Bang(Deck deck) : Card("Bang", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            Player target = GetTargets(player, targets);
            bool blocked = false;
            Utility.WriteColoredLine("{GAME} " + player.Name + " used Bang on " + target.Name, ConsoleColor.Yellow);
            if (!blocked)
            {
                target.Lives--;
            }
            RemoveCard(player);
        }
    }
}
