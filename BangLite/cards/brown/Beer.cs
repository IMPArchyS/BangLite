using BangLite.Decks;
using BangLite.Players;
using BangLite.Utils;

namespace BangLite.Cards.Brown
{
    public class Beer(Deck deck) : Card("Beer", deck)
    {
        public override void UseCard(Player player, List<Player> targets)
        {
            player.Lives++;
            Utility.WriteColoredLine("{GAME} " + player.Name + " used Beer!", ConsoleColor.Yellow);
            RemoveCard(player);
        }
    }
}
